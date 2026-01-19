namespace ServiceLib.Manager;

public sealed record PacUserRules(IReadOnlyList<string> DirectDomains, IReadOnlyList<string> ProxyDomains);

public static class PacUserRuleManager
{
    private const string DirectFileName = "userDirectPac.txt";
    private const string ProxyFileName = "userProxyPac.txt";

    public static PacUserRules? Load(string configPath)
    {
        var directPath = Path.Combine(configPath, DirectFileName);
        var proxyPath = Path.Combine(configPath, ProxyFileName);

        if (!File.Exists(directPath) || !File.Exists(proxyPath))
        {
            return null;
        }

        var direct = NormalizeDomains(File.ReadAllText(directPath));
        var proxy = NormalizeDomains(File.ReadAllText(proxyPath));

        return new PacUserRules(direct, proxy);
    }

    public static void Save(string directDomains, string proxyDomains, string configPath)
    {
        var directPath = Path.Combine(configPath, DirectFileName);
        var proxyPath = Path.Combine(configPath, ProxyFileName);

        var direct = string.Join(Environment.NewLine, NormalizeDomains(directDomains));
        var proxy = string.Join(Environment.NewLine, NormalizeDomains(proxyDomains));

        File.WriteAllText(directPath, direct);
        File.WriteAllText(proxyPath, proxy);
    }

    private static IReadOnlyList<string> NormalizeDomains(string? domains)
    {
        if (string.IsNullOrWhiteSpace(domains))
        {
            return [];
        }

        return domains
            .Replace("\r\n", "\n")
            .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Where(d => d.IsNotEmpty())
            .ToList();
    }
}
