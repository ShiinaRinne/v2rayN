﻿using v2rayN.Base;
using v2rayN.Mode;
using v2rayN.Resx;

namespace v2rayN.Handler
{
    internal class CoreConfigSingbox
    {
        private string SampleClient = Global.SingboxSampleClient;
        private Config _config;

        public CoreConfigSingbox(Config config)
        {
            _config = config;
        }

        public int GenerateClientConfigContent(ProfileItem node, out SingboxConfig? singboxConfig, out string msg)
        {
            singboxConfig = null;
            try
            {
                if (node == null
                    || node.port <= 0)
                {
                    msg = ResUI.CheckServerSettings;
                    return -1;
                }

                msg = ResUI.InitialConfiguration;

                string result = Utils.GetEmbedText(SampleClient);
                if (Utils.IsNullOrEmpty(result))
                {
                    msg = ResUI.FailedGetDefaultConfiguration;
                    return -1;
                }

                singboxConfig = Utils.FromJson<SingboxConfig>(result);
                if (singboxConfig == null)
                {
                    msg = ResUI.FailedGenDefaultConfiguration;
                    return -1;
                }

                log(singboxConfig);

                inbound(singboxConfig);

                outbound(node, singboxConfig);

                routing(singboxConfig);

                dns(singboxConfig);

                //statistic(singboxConfig);

                msg = string.Format(ResUI.SuccessfulConfiguration, "");
            }
            catch (Exception ex)
            {
                Utils.SaveLog("GenerateClientConfig4Singbox", ex);
                msg = ResUI.FailedGenDefaultConfiguration;
                return -1;
            }
            return 0;
        }

        private int log(SingboxConfig singboxConfig)
        {
            try
            {
                switch (_config.coreBasicItem.loglevel)
                {
                    case "debug":
                    case "info":
                    case "error":
                        singboxConfig.log.level = _config.coreBasicItem.loglevel;
                        break;

                    case "warn":
                        singboxConfig.log.level = "warning";
                        break;

                    default:
                        break;
                }
                if (_config.coreBasicItem.loglevel == "none")
                {
                    singboxConfig.log.disabled = true;
                }
                if (_config.coreBasicItem.logEnabled)
                {
                    var dtNow = DateTime.Now;
                    singboxConfig.log.output = Utils.GetLogPath($"sbox_{dtNow:yyyy-MM-dd}.txt");
                }
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
            return 0;
        }

        #region inbound private

        private int inbound(SingboxConfig singboxConfig)
        {
            try
            {
                if (_config.tunModeItem.enableTun)
                {
                    singboxConfig.inbounds.Clear();

                    if (_config.tunModeItem.mtu <= 0)
                    {
                        _config.tunModeItem.mtu = Convert.ToInt32(Global.TunMtus[0]);
                    }
                    if (Utils.IsNullOrEmpty(_config.tunModeItem.stack))
                    {
                        _config.tunModeItem.stack = Global.TunStacks[0];
                    }

                    var tunInbound = Utils.FromJson<Inbound4Sbox>(Utils.GetEmbedText(Global.TunSingboxInboundFileName));
                    tunInbound.mtu = _config.tunModeItem.mtu;
                    tunInbound.strict_route = _config.tunModeItem.strictRoute;
                    tunInbound.stack = _config.tunModeItem.stack;

                    singboxConfig.inbounds.Add(tunInbound);
                }
                else
                {
                    var inbound = singboxConfig.inbounds[0];
                    inbound.listen_port = LazyConfig.Instance.GetLocalPort(Global.InboundSocks);
                    inbound.sniff = _config.inbound[0].sniffingEnabled;
                    inbound.sniff_override_destination = _config.inbound[0].routeOnly ? false : _config.inbound[0].sniffingEnabled;
                    inbound.domain_strategy = Utils.IsNullOrEmpty(_config.routingBasicItem.domainStrategy4Singbox) ? null: _config.routingBasicItem.domainStrategy4Singbox;

                    //http
                    var inbound2 = GetInbound(inbound, Global.InboundHttp, 1, false);
                    singboxConfig.inbounds.Add(inbound2);

                    if (_config.inbound[0].allowLANConn)
                    {
                        if (_config.inbound[0].newPort4LAN)
                        {
                            var inbound3 = GetInbound(inbound, Global.InboundSocks2, 2, true);
                            inbound3.listen = "::";
                            singboxConfig.inbounds.Add(inbound3);

                            var inbound4 = GetInbound(inbound, Global.InboundHttp2, 3, false);
                            inbound4.listen = "::";
                            singboxConfig.inbounds.Add(inbound4);

                            //auth
                            if (!Utils.IsNullOrEmpty(_config.inbound[0].user) && !Utils.IsNullOrEmpty(_config.inbound[0].pass))
                            {
                                inbound3.users = new() { new() { username = _config.inbound[0].user, password = _config.inbound[0].pass } };
                                inbound4.users = new() { new() { username = _config.inbound[0].user, password = _config.inbound[0].pass } };
                            }
                        }
                        else
                        {
                            inbound.listen = "::";
                            inbound2.listen = "::";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
            return 0;
        }

        private Inbound4Sbox? GetInbound(Inbound4Sbox inItem, string tag, int offset, bool bSocks)
        {
            var inbound = Utils.DeepCopy(inItem);
            inbound.tag = tag;
            inbound.listen_port = inItem.listen_port + offset;
            inbound.type = bSocks ? Global.InboundSocks : Global.InboundHttp;
            return inbound;
        }

        #endregion inbound private

        #region outbound private

        private int outbound(ProfileItem node, SingboxConfig singboxConfig)
        {
            try
            {
                if (_config.tunModeItem.enableTun)
                {
                    singboxConfig.outbounds.Add(new()
                    {
                        type = "dns",
                        tag = "dns_out"
                    });
                }

                var outbound = singboxConfig.outbounds[0];
                outbound.server = node.address;
                outbound.server_port = node.port;

                if (node.configType == EConfigType.VMess)
                {
                    outbound.type = Global.vmessProtocolLite;

                    outbound.uuid = node.id;
                    outbound.alter_id = node.alterId;
                    if (Global.vmessSecuritys.Contains(node.security))
                    {
                        outbound.security = node.security;
                    }
                    else
                    {
                        outbound.security = Global.DefaultSecurity;
                    }

                    outboundMux(node, outbound);
                }
                else if (node.configType == EConfigType.Shadowsocks)
                {
                    outbound.type = Global.ssProtocolLite;

                    outbound.method = LazyConfig.Instance.GetShadowsocksSecuritys(node).Contains(node.security) ? node.security : "none";
                    outbound.password = node.id;

                    outboundMux(node, outbound);
                }
                else if (node.configType == EConfigType.Socks)
                {
                    outbound.type = Global.socksProtocolLite;

                    outbound.version = "5";
                    if (!Utils.IsNullOrEmpty(node.security)
                      && !Utils.IsNullOrEmpty(node.id))
                    {
                        outbound.username = node.security;
                        outbound.password = node.id;
                    }
                }
                else if (node.configType == EConfigType.VLESS)
                {
                    outbound.type = Global.vlessProtocolLite;

                    outbound.uuid = node.id;
                    outbound.flow = node.flow;

                    outbound.packet_encoding = "xudp";
                }
                else if (node.configType == EConfigType.Trojan)
                {
                    outbound.type = Global.trojanProtocolLite;

                    outbound.password = node.id;

                    outboundMux(node, outbound);
                }

                outboundTls(node, outbound);

                outboundTransport(node, outbound);
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
            return 0;
        }

        private int outboundMux(ProfileItem node, Outbound4Sbox outbound)
        {
            try
            {
                if (_config.coreBasicItem.muxEnabled)
                {
                    var mux = new Multiplex4Sbox()
                    {
                        enabled = true,
                        protocol = "smux",
                        max_connections = 4,
                        min_streams = 4,
                        max_streams = 0,
                    };
                    outbound.multiplex = mux;
                }
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
            return 0;
        }

        private int outboundTls(ProfileItem node, Outbound4Sbox outbound)
        {
            try
            {
                if (node.streamSecurity == Global.StreamSecurityReality || node.streamSecurity == Global.StreamSecurity)
                {
                    var tls = new Tls4Sbox()
                    {
                        enabled = true,
                        server_name = node.sni,
                        insecure = Utils.ToBool(node.allowInsecure.IsNullOrEmpty() ? _config.coreBasicItem.defAllowInsecure.ToString().ToLower() : node.allowInsecure),
                        alpn = node.GetAlpn(),
                    };
                    if (!Utils.IsNullOrEmpty(node.fingerprint))
                    {
                        tls.utls = new Utls4Sbox()
                        {
                            enabled = true,
                            fingerprint = node.fingerprint.IsNullOrEmpty() ? _config.coreBasicItem.defFingerprint : node.fingerprint
                        };
                    }
                    if (node.streamSecurity == Global.StreamSecurityReality)
                    {
                        tls.reality = new Reality4Sbox()
                        {
                            enabled = true,
                            public_key = node.publicKey,
                            short_id = node.shortId
                        };
                    }
                    outbound.tls = tls;
                }
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
            return 0;
        }

        private int outboundTransport(ProfileItem node, Outbound4Sbox outbound)
        {
            try
            {
                var transport = new Transport4Sbox();

                switch (node.GetNetwork())
                {
                    case "h2":
                        transport.type = "http";
                        transport.host = Utils.IsNullOrEmpty(node.requestHost) ? null : Utils.String2List(node.requestHost);
                        transport.path = Utils.IsNullOrEmpty(node.path) ? null : node.path;
                        break;

                    case "ws":
                        transport.type = "ws";
                        transport.path = Utils.IsNullOrEmpty(node.path) ? null : node.path;
                        break;

                    case "quic":
                        transport.type = "quic";
                        break;

                    case "grpc":
                        transport.type = "grpc";
                        transport.service_name = node.path;
                        transport.idle_timeout = _config.grpcItem.idle_timeout.ToString("##s");
                        transport.ping_timeout = _config.grpcItem.health_check_timeout.ToString("##s");
                        transport.permit_without_stream = _config.grpcItem.permit_without_stream;
                        break;

                    default:
                        transport = null;
                        break;
                }

                outbound.transport = transport;
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
            return 0;
        }

        #endregion outbound private

        #region routing rule private

        private int routing(SingboxConfig singboxConfig)
        {
            try
            {
                if (_config.tunModeItem.enableTun)
                {
                    singboxConfig.route.auto_detect_interface = true;

                    var tunRules = Utils.FromJson<List<Rule4Sbox>>(Utils.GetEmbedText(Global.TunSingboxRulesFileName));
                    singboxConfig.route.rules.AddRange(tunRules);

                    routingDirectExe(out List<string> lstDnsExe, out List<string> lstDirectExe);
                    singboxConfig.route.rules.Add(new()
                    {
                        port = new() { 53 },
                        outbound = "dns_out",
                        process_name = lstDnsExe
                    });

                    singboxConfig.route.rules.Add(new()
                    {
                        outbound = "direct",
                        process_name = lstDirectExe
                    });
                }

                if (_config.routingBasicItem.enableRoutingAdvanced)
                {
                    var routing = ConfigHandler.GetDefaultRouting(ref _config);
                    if (routing != null)
                    {
                        var rules = Utils.FromJson<List<RulesItem>>(routing.ruleSet);
                        foreach (var item in rules!)
                        {
                            if (item.enabled)
                            {
                                routingUserRule(item, singboxConfig.route.rules);
                            }
                        }
                    }
                }
                else
                {
                    var lockedItem = ConfigHandler.GetLockedRoutingItem(ref _config);
                    if (lockedItem != null)
                    {
                        var rules = Utils.FromJson<List<RulesItem>>(lockedItem.ruleSet);
                        foreach (var item in rules!)
                        {
                            routingUserRule(item, singboxConfig.route.rules);
                        }
                    }
                }

                if (_config.tunModeItem.enableTun)
                {
                    if (_config.tunModeItem.bypassMode)
                    {
                        //direct ips
                        if (_config.tunModeItem.directIP != null && _config.tunModeItem.directIP.Count > 0)
                        {
                            singboxConfig.route.rules.Add(new() { outbound = "direct", ip_cidr = _config.tunModeItem.directIP });
                        }
                        //direct process
                        if (_config.tunModeItem.directProcess != null && _config.tunModeItem.directProcess.Count > 0)
                        {
                            singboxConfig.route.rules.Add(new() { outbound = "direct", process_name = _config.tunModeItem.directProcess });
                        }
                    }
                    else
                    {
                        //proxy ips
                        if (_config.tunModeItem.proxyIP != null && _config.tunModeItem.proxyIP.Count > 0)
                        {
                            singboxConfig.route.rules.Add(new() { outbound = "proxy", ip_cidr = _config.tunModeItem.proxyIP });
                        }
                        //proxy process
                        if (_config.tunModeItem.proxyProcess != null && _config.tunModeItem.proxyProcess.Count > 0)
                        {
                            singboxConfig.route.rules.Add(new() { outbound = "proxy", process_name = _config.tunModeItem.proxyProcess });
                        }

                        singboxConfig.route.rules.Add(new() { outbound = "direct", inbound = new() { "tun-in" } });
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
            return 0;
        }

        private void routingDirectExe(out List<string> lstDnsExe, out List<string> lstDirectExe)
        {
            lstDnsExe = new();
            lstDirectExe = new();
            var coreInfos = LazyConfig.Instance.GetCoreInfos();
            foreach (var it in coreInfos)
            {
                if (it.coreType == ECoreType.v2rayN)
                {
                    continue;
                }
                foreach (var it2 in it.coreExes)
                {
                    if (!lstDnsExe.Contains(it2) && it.coreType != ECoreType.sing_box)
                    {
                        lstDnsExe.Add($"{it2}.exe");
                    }

                    if (!lstDirectExe.Contains(it2))
                    {
                        lstDirectExe.Add($"{it2}.exe");
                    }
                }
            }
        }

        private int routingUserRule(RulesItem item, List<Rule4Sbox> rules)
        {
            try
            {
                if (item == null)
                {
                    return 0;
                }

                var rule = new Rule4Sbox()
                {
                    outbound = item.outboundTag,
                };

                if (!Utils.IsNullOrEmpty(item.port))
                {
                    if (item.port.Contains("-"))
                    {
                        rule.port_range = new List<string> { item.port.Replace("-", ":") };
                    }
                    else
                    {
                        rule.port = new List<int> { Utils.ToInt(item.port) };
                    }
                }
                if (item.protocol?.Count > 0)
                {
                    rule.protocol = item.protocol;
                }
                if (item.inboundTag?.Count >= 0)
                {
                    rule.inbound = item.inboundTag;
                }
                var rule2 = Utils.DeepCopy(rule);

                var hasDomainIp = false;
                if (item.domain?.Count > 0)
                {
                    foreach (var it in item.domain)
                    {
                        parseV2Domain(it, rule);
                    }
                    rules.Add(rule);
                    hasDomainIp = true;
                }

                if (item.ip?.Count > 0)
                {
                    foreach (var it in item.ip)
                    {
                        parseV2Address(it, rule2);
                    }
                    rules.Add(rule2);
                    hasDomainIp = true;
                }

                if (!hasDomainIp)
                {
                    rules.Add(rule);
                }
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
            return 0;
        }

        private void parseV2Domain(string domain, Rule4Sbox rule)
        {
            if (domain.StartsWith("ext:") || domain.StartsWith("ext-domain:"))
            {
                return;
            }
            else if (domain.StartsWith("geosite:"))
            {
                if (rule.geosite is null) { rule.geosite = new(); }
                rule.geosite?.Add(domain.Substring(8));
            }
            else if (domain.StartsWith("regexp:"))
            {
                if (rule.domain_regex is null) { rule.domain_regex = new(); }
                rule.domain_regex?.Add(domain.Replace(Global.RoutingRuleComma, ",").Substring(7));
            }
            else if (domain.StartsWith("domain:"))
            {
                if (rule.domain is null) { rule.domain = new(); }
                if (rule.domain_suffix is null) { rule.domain_suffix = new(); }
                rule.domain?.Add(domain.Substring(7));
                rule.domain_suffix?.Add("." + domain.Substring(7));
            }
            else if (domain.StartsWith("full:"))
            {
                if (rule.domain is null) { rule.domain = new(); }
                rule.domain?.Add(domain.Substring(5));
            }
            else if (domain.StartsWith("keyword:"))
            {
                if (rule.domain_keyword is null) { rule.domain_keyword = new(); }
                rule.domain_keyword?.Add(domain.Substring(8));
            }
            else
            {
                if (rule.domain_keyword is null) { rule.domain_keyword = new(); }
                rule.domain_keyword?.Add(domain);
            }
        }

        private void parseV2Address(string address, Rule4Sbox rule)
        {
            if (address.StartsWith("ext:") || address.StartsWith("ext-ip:"))
            {
                return;
            }
            else if (address.StartsWith("geoip:!"))
            {
                return;
            }
            else if (address.StartsWith("geoip:"))
            {
                if (rule.geoip is null) { rule.geoip = new(); }
                rule.geoip?.Add(address.Substring(6));
            }
            else
            {
                if (rule.ip_cidr is null) { rule.ip_cidr = new(); }
                rule.ip_cidr?.Add(address);
            }
        }

        #endregion routing rule private

        private int dns(SingboxConfig singboxConfig)
        {
            try
            {
                if (_config.tunModeItem.enableTun)
                {
                    var tunDNS = Utils.GetEmbedText(Global.TunSingboxDNSFileName);
                    var obj = Utils.ParseJson(tunDNS);
                    singboxConfig.dns = obj;
                }
                else
                {
                    var item = LazyConfig.Instance.GetDNSItem(ECoreType.sing_box);
                    var normalDNS = item?.normalDNS;
                    if (string.IsNullOrWhiteSpace(normalDNS))
                    {
                        return 0;
                    }

                    var obj = Utils.ParseJson(normalDNS);
                    if (obj?.ContainsKey("servers") == true)
                    {
                        singboxConfig.dns = obj;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
            return 0;
        }

        private int statistic(SingboxConfig singboxConfig)
        {
            if (_config.guiItem.enableStatistics)
            {
                singboxConfig.experimental = new Experimental4Sbox()
                {
                    v2ray_api = new V2ray_Api4Sbox()
                    {
                        listen = $"{Global.Loopback}:{Global.statePort}",
                        stats = new Stats4Sbox()
                        {
                            enabled = true,
                        }
                    }
                };
            }
            return 0;
        }
    }
}