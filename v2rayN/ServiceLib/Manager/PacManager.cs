namespace ServiceLib.Manager;

public class PacManager
{
    private const string UserPacDirectPlaceholder = "__USERPAC_DIRECT__";
    private const string UserPacProxyPlaceholder = "__USERPAC_PROXY__";

    private static readonly Lazy<PacManager> _instance = new(() => new PacManager());
    public static PacManager Instance => _instance.Value;

    private int _httpPort;
    private int _pacPort;
    private TcpListener? _tcpListener;
    private byte[] _writeContent;
    private bool _isRunning;
    private bool _needRestart = true;

    public async Task StartAsync(int httpPort, int pacPort, bool forceReload = false)
    {
        _needRestart = httpPort != _httpPort || pacPort != _pacPort || !_isRunning || forceReload;

        _httpPort = httpPort;
        _pacPort = pacPort;

        await InitText();

        if (_needRestart)
        {
            Stop();
            RunListener();
        }
    }

    public async Task ReloadAsync()
    {
        if (_httpPort <= 0 || _pacPort <= 0)
        {
            return;
        }
        await StartAsync(_httpPort, _pacPort, forceReload: true);
    }

    private async Task InitText()
    {
        var customSystemProxyPacPath = AppManager.Instance.Config.SystemProxyItem?.CustomSystemProxyPacPath;
        var fileName = (customSystemProxyPacPath.IsNotEmpty() && File.Exists(customSystemProxyPacPath))
            ? customSystemProxyPacPath
            : Path.Combine(Utils.GetConfigPath(), "pac.txt");

        // TODO: temporarily notify which script is being used
        NoticeManager.Instance.SendMessage(fileName);

        if (!File.Exists(fileName))
        {
            var pac = EmbedUtils.GetEmbedText(Global.PacFileName);
            await File.AppendAllTextAsync(fileName, pac);
        }

        var pacText = await File.ReadAllTextAsync(fileName);
        pacText = pacText.Replace("__PROXY__", $"PROXY 127.0.0.1:{_httpPort};DIRECT;");
        pacText = ApplyUserPacRules(pacText);

        var sb = new StringBuilder();
        sb.AppendLine("HTTP/1.0 200 OK");
        sb.AppendLine("Content-type:application/x-ns-proxy-autoconfig");
        sb.AppendLine("Connection:close");
        sb.AppendLine("Content-Length:" + Encoding.UTF8.GetByteCount(pacText));
        sb.AppendLine();
        sb.Append(pacText);
        _writeContent = Encoding.UTF8.GetBytes(sb.ToString());
    }

    private static string ApplyUserPacRules(string pacText)
    {
        var configPath = Utils.GetConfigPath();
        var userRules = PacUserRuleManager.Load(configPath);

        var directItems = userRules is null
            ? string.Empty
            : ToJsArrayItems(userRules.DirectDomains);
        var proxyItems = userRules is null
            ? string.Empty
            : ToJsArrayItems(userRules.ProxyDomains);

        if (pacText.Contains(UserPacDirectPlaceholder, StringComparison.Ordinal) ||
            pacText.Contains(UserPacProxyPlaceholder, StringComparison.Ordinal))
        {
            pacText = pacText.Replace(UserPacDirectPlaceholder, directItems);
            pacText = pacText.Replace(UserPacProxyPlaceholder, proxyItems);
            return pacText;
        }

        // Fallback: replace the last empty rule set block: [ [], [] ]
        // This keeps user rules functional even when using third-party PAC scripts.
        var replaced = ReplaceLastEmptyRuleSet(pacText, directItems, proxyItems);
        return replaced ?? pacText;
    }

    private static string ToJsArrayItems(IReadOnlyList<string> domains)
    {
        if (domains.Count == 0)
        {
            return string.Empty;
        }

        var indent = "            ";
        return string.Join($",{Environment.NewLine}{indent}", domains.Select(d => $"\"{EscapeJsString(d)}\""));
    }

    private static string EscapeJsString(string value)
    {
        return value
            .Replace("\\", "\\\\")
            .Replace("\"", "\\\"");
    }

    private static string? ReplaceLastEmptyRuleSet(string pacText, string directItems, string proxyItems)
    {
        // Match "[<ws>[],<ws>[]]" with arbitrary whitespace/newlines and replace the last occurrence.
        var regex = new Regex(@"\[\s*\[\s*\]\s*,\s*\[\s*\]\s*\]", RegexOptions.RightToLeft);
        var match = regex.Match(pacText);
        if (!match.Success)
        {
            return null;
        }

        var directArray = directItems.IsNullOrEmpty()
            ? "[]"
            : $"[{Environment.NewLine}            {directItems}{Environment.NewLine}        ]";
        var proxyArray = proxyItems.IsNullOrEmpty()
            ? "[]"
            : $"[{Environment.NewLine}            {proxyItems}{Environment.NewLine}        ]";

        var replacement = $"[{directArray},{Environment.NewLine}        {proxyArray}]";
        return pacText[..match.Index] + replacement + pacText[(match.Index + match.Length)..];
    }

    private void RunListener()
    {
        _tcpListener = TcpListener.Create(_pacPort);
        _isRunning = true;
        _tcpListener.Start();
        Task.Factory.StartNew(async () =>
        {
            while (_isRunning)
            {
                try
                {
                    if (!_tcpListener.Pending())
                    {
                        await Task.Delay(10);
                        continue;
                    }

                    var client = await _tcpListener.AcceptTcpClientAsync();
                    await Task.Run(() => WriteContent(client));
                }
                catch
                {
                    // ignored
                }
            }
        }, TaskCreationOptions.LongRunning);
    }

    private void WriteContent(TcpClient client)
    {
        var stream = client.GetStream();
        stream.Write(_writeContent, 0, _writeContent.Length);
        stream.Flush();
    }

    public void Stop()
    {
        if (_tcpListener == null)
        {
            return;
        }
        try
        {
            _isRunning = false;
            _tcpListener.Stop();
            _tcpListener = null;
        }
        catch
        {
            // ignored
        }
    }
}
