﻿using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using v2rayN.Mode;
using v2rayN.Resx;

namespace v2rayN.Handler
{
    class SpeedtestHandler
    {
        private Config _config;
        private CoreHandler _coreHandler;
        private List<ServerTestItem> _selecteds;
        Action<string, string, string> _updateFunc;

        public SpeedtestHandler(Config config)
        {
            _config = config;
        }

        public SpeedtestHandler(Config config, CoreHandler coreHandler, List<ProfileItem> selecteds, ESpeedActionType actionType, Action<string, string, string> update)
        {
            _config = config;
            _coreHandler = coreHandler;
            //_selecteds = Utils.DeepCopy(selecteds);
            _updateFunc = update;

            _selecteds = new List<ServerTestItem>();
            foreach (var it in selecteds)
            {
                _selecteds.Add(new ServerTestItem()
                {
                    indexId = it.indexId,
                    address = it.address,
                    port = it.port,
                    configType = it.configType
                });
            }
            switch (actionType)
            {
                case ESpeedActionType.Ping:
                    Task.Run(RunPing);
                    break;
                case ESpeedActionType.Tcping:
                    Task.Run(RunTcping);
                    break;
                case ESpeedActionType.Realping:
                    Task.Run(RunRealPing);
                    break;
                case ESpeedActionType.Speedtest:
                    Task.Run(RunSpeedTestAsync);
                    break;
                case ESpeedActionType.Mixedtest:
                    Task.Run(RunMixedtestAsync);
                    break;
            }
        }

        private void RunPingSub(Action<ServerTestItem> updateFun)
        {
            try
            {
                foreach (var it in _selecteds.Where(it => it.configType != EConfigType.Custom))
                {
                    try
                    {
                        Task.Run(() => updateFun(it));
                    }
                    catch (Exception ex)
                    {
                        Utils.SaveLog(ex.Message, ex);
                    }
                }

                Thread.Sleep(10);
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
        }


        private void RunPing()
        {
            RunPingSub((ServerTestItem it) =>
            {
                long time = Ping(it.address);
                var output = FormatOut(time, Global.DelayUnit);

                LazyConfig.Instance.SetTestResult(it.indexId, output, "");
                UpdateFunc(it.indexId, output);
            });
        }

        private void RunTcping()
        {
            RunPingSub((ServerTestItem it) =>
            {
                int time = GetTcpingTime(it.address, it.port);
                var output = FormatOut(time, Global.DelayUnit);

                LazyConfig.Instance.SetTestResult(it.indexId, output, "");
                UpdateFunc(it.indexId, output);
            });
        }

        private async Task RunRealPing()
        {
            int pid = -1;
            try
            {
                string msg = string.Empty;

                pid = _coreHandler.LoadCoreConfigString(_config, _selecteds);
                if (pid < 0)
                {
                    UpdateFunc("", ResUI.FailedToRunCore);
                    return;
                }

                DownloadHandle downloadHandle = new DownloadHandle();
                //Thread.Sleep(5000);
                List<Task> tasks = new List<Task>();
                foreach (var it in _selecteds)
                {
                    if (!it.allowTest)
                    {
                        continue;
                    }
                    if (it.configType == EConfigType.Custom)
                    {
                        continue;
                    }
                    tasks.Add(Task.Run(() =>
                    {
                        try
                        {
                            LazyConfig.Instance.SetTestResult(it.indexId, "-1", "");

                            WebProxy webProxy = new WebProxy(Global.Loopback, it.port);
                            string output = GetRealPingTime(downloadHandle, webProxy);

                            LazyConfig.Instance.SetTestResult(it.indexId, output, "");
                            UpdateFunc(it.indexId, output);
                        }
                        catch (Exception ex)
                        {
                            Utils.SaveLog(ex.Message, ex);
                        }
                    }));
                    //Thread.Sleep(100);
                }
                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
            finally
            {
                if (pid > 0) _coreHandler.CoreStopPid(pid);
            }
        }
        private async Task RunSpeedTestAsync()
        {
            int pid = -1;

            pid = _coreHandler.LoadCoreConfigString(_config, _selecteds);
            if (pid < 0)
            {
                UpdateFunc("", ResUI.FailedToRunCore);
                return;
            }

            string url = _config.constItem.speedTestUrl;
            DownloadHandle downloadHandle = new DownloadHandle();

            var timeout = 10;
            foreach (var it in _selecteds)
            {
                if (!it.allowTest)
                {
                    continue;
                }
                if (it.configType == EConfigType.Custom)
                {
                    continue;
                }
                _ = LazyConfig.Instance.SetTestResult(it.indexId, "", "-1");
                UpdateFunc(it.indexId, "", ResUI.Speedtesting);

                var item = LazyConfig.Instance.GetProfileItem(it.indexId);
                if (item is null) continue;

                WebProxy webProxy = new WebProxy(Global.Loopback, it.port);

                await downloadHandle.DownloadDataAsync(url, webProxy, timeout, (bool success, string msg) =>
                {
                    decimal.TryParse(msg, out decimal dec);
                    if (dec > 0)
                    {
                        _ = LazyConfig.Instance.SetTestResult(it.indexId, "", msg);
                    }
                    UpdateFunc(it.indexId, "", msg);
                });
            }

            if (pid > 0)
            {
                _coreHandler.CoreStopPid(pid);
            }
        }
        private async Task RunMixedtestAsync()
        {
            await RunRealPing();

            await RunSpeedTestAsync();
        }

        public string GetRealPingTime(DownloadHandle downloadHandle, WebProxy webProxy)
        {
            string status = downloadHandle.GetRealPingTime(_config.constItem.speedPingTestUrl, webProxy, 10, out int responseTime);
            //string output = Utils.IsNullOrEmpty(status) ? FormatOut(responseTime, "ms") : status;
            return FormatOut(Utils.IsNullOrEmpty(status) ? responseTime : -1, Global.DelayUnit);
        }

        private int GetTcpingTime(string url, int port)
        {
            int responseTime = -1;

            try
            {
                if (!IPAddress.TryParse(url, out IPAddress ipAddress))
                {
                    IPHostEntry ipHostInfo = System.Net.Dns.GetHostEntry(url);
                    ipAddress = ipHostInfo.AddressList[0];
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();

                IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
                Socket clientSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                IAsyncResult result = clientSocket.BeginConnect(endPoint, null, null);
                if (!result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5)))
                    throw new TimeoutException("connect timeout (5s): " + url);
                clientSocket.EndConnect(result);

                timer.Stop();
                responseTime = timer.Elapsed.Milliseconds;
                clientSocket.Close();
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
            return responseTime;
        }


        /// <summary>
        /// Ping
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public long Ping(string host)
        {
            long roundtripTime = -1;
            try
            {
                int timeout = 30;
                int echoNum = 2;
                Ping pingSender = new Ping();
                for (int i = 0; i < echoNum; i++)
                {
                    PingReply reply = pingSender.Send(host, timeout);
                    if (reply.Status == IPStatus.Success)
                    {
                        if (reply.RoundtripTime < 0)
                        {
                            continue;
                        }
                        if (roundtripTime < 0 || reply.RoundtripTime < roundtripTime)
                        {
                            roundtripTime = reply.RoundtripTime;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
                return -1;
            }
            return roundtripTime;
        }

        private string FormatOut(object time, string unit)
        {
            //if (time.ToString().Equals("-1"))
            //{
            //    return "Timeout";
            //}
            return $"{time}";
        }

        private void UpdateFunc(string indexId, string delay, string speed = "")
        {
            _updateFunc(indexId, delay, speed);
        }
    }
}
