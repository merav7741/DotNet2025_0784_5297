using System.Xml.Linq;

namespace Dal;

internal static class Config
{
    static readonly string PATH =
    Path.Combine(AppContext.BaseDirectory, "xml", "config.xml");

    const string PRODUCT = "ProductNum";
    const string SALE = "SaleNum";

    static XElement xml = Load();

    private static XElement Load()
    {
        var dir = Path.GetDirectoryName(PATH);
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir!);

        if (!File.Exists(PATH))
        {
            var x = new XElement("config",
                new XElement(PRODUCT, "1000"),
                new XElement(SALE, "1000"));

            x.Save(PATH);
            return x;
        }

        return XElement.Load(PATH);
    }

    private static int nextProduct = int.Parse(xml.Element(PRODUCT)!.Value);
    private static int nextSale = int.Parse(xml.Element(SALE)!.Value);

    public static int NextProductNum
    {
        get
        {
            int cur = nextProduct++;
            xml.Element(PRODUCT)!.Value = nextProduct.ToString();
            xml.Save(PATH);
            return cur;
        }
    }

    public static int NextSaleNum
    {
        get
        {
            int cur = nextSale++;
            xml.Element(SALE)!.Value = nextSale.ToString();
            xml.Save(PATH);
            return cur;
        }
    }
}