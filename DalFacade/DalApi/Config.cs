namespace DalApi;
using System.Xml.Linq;

static class DalConfig
{
    internal static string s_dalName;
    internal static Dictionary<string, string> s_dalPackages;

    static DalConfig()
    {
        string configPath = Path.Combine(AppContext.BaseDirectory, "xml", "dal-config.xml");

        XElement dalConfig = XElement.Load(configPath);

        s_dalName = dalConfig.Element("dal")?.Value
            ?? throw new DalConfigException("<dal> element is missing");

        var dalPackagesElement = dalConfig.Element("dal-packages")
            ?? throw new DalConfigException("<dal-packages> element is missing");

        s_dalPackages = dalPackagesElement.Elements()
            .ToDictionary(p => p.Name.LocalName, p => p.Value);
    }
}

[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}


