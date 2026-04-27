using System;
using System.IO;
using System.Xml.Linq;

namespace Dal;

internal static class Config
{
    static readonly string path = Path.Combine(AppContext.BaseDirectory, "xml", "data-config.xml");

    const string PRODUCT_TAG = "ProductNum";
    const string SALE_TAG = "SaleNum";

    static XElement dataConfigXml = Initialize();

    private static XElement Initialize()
    {
        var dir = Path.GetDirectoryName(path);
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        if (!File.Exists(path))
        {
            var defaultXml = new XElement("config",
                new XElement(PRODUCT_TAG, "1000"),
                new XElement(SALE_TAG, "1000")   
            );
            defaultXml.Save(path);
            return defaultXml;
        }

        try
        {
            return XElement.Load(path);
        }
        catch
        {
            var fallback = new XElement("config",
                new XElement(PRODUCT_TAG, "1000"),
                new XElement(SALE_TAG, "1000")
            );
            fallback.Save(path);
            return fallback;
        }
    }

    private static int _nextProductNum = int.Parse(dataConfigXml.Element(PRODUCT_TAG).Value);
    private static int _nextSaleNum = int.Parse(dataConfigXml.Element(SALE_TAG).Value);

    public static int NextProductNum
    {
        get
        {
            int current = _nextProductNum; 
            _nextProductNum++;            

            dataConfigXml.Element(PRODUCT_TAG).SetValue(_nextProductNum);
            dataConfigXml.Save(path);

            return current;
        }
    }

    public static int NextSaleNum
    {
        get
        {
            int current = _nextSaleNum;
            _nextSaleNum++;

            dataConfigXml.Element(SALE_TAG).SetValue(_nextSaleNum);
            dataConfigXml.Save(path);

            return current;
        }
    }
}