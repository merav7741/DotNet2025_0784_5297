using System.Xml.Linq;

namespace Dal;

internal static class Config
{
    private const string configurationFileName = "../xml/data-config.xml";

    public static int ProductNum
    {
        get
        {
            XElement file = XElement.Load(configurationFileName);
            XElement curProdNum = file.Element("ProductNum")!;
            int num = int.Parse(curProdNum.Value);
            curProdNum.SetValue(num + 1);
            file.Save(configurationFileName);
            return num;
        }
    }

    public static int SaleNum
    {
        get
        {
            XElement file = XElement.Load(configurationFileName);
            XElement curSaleNum = file.Element("SaleNum")!;
            int num = int.Parse(curSaleNum.Value);
            curSaleNum.SetValue(num + 1);
            file.Save(configurationFileName);
            return num;
        }
    }
}
