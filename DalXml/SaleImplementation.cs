using System.Xml.Serialization;
using DalApi;
using DO;

namespace Dal;

internal class SaleImplementation : ISale
{
    private const string SALES_FILE_PATH = @"D:\מירב לימודים יד\C#\project .net\.NET\xml\sales.xml";

    public int Create(Sale s)
    {
        int myId = Config.SaleNum;
        s = s with { Id = myId };
        List<Sale> salesList = Load();
        salesList.Add(s);
        Save(salesList);
        return s.Id;
    }

    public void Delete(int id)
    {
        List<Sale> salesList = Load();
        Sale? sale = salesList.FirstOrDefault(x => x.Id == id);
        if (sale == null)
            throw new DalNotExistException($"Sale with id: {id} was not found");
        salesList.Remove(sale);
        Save(salesList);
    }

    public Sale? Read(int id)
    {
        List<Sale> salesList = Load();
        return salesList.FirstOrDefault(x => x.Id == id) ?? throw new DalNotExistException($"Sale with id: {id} was not found");
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        return Load().FirstOrDefault(filter);
    }

    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        List<Sale> salesList = Load();
        return filter == null ? salesList : salesList.Where(filter).ToList();
    }

    public void Update(Sale sale)
    {
        List<Sale> salesList = Load();
        int index = salesList.FindIndex(s => s.Id == sale.Id);
        if (index < 0)
            throw new DalNotExistException($"Sale with id: {sale.Id} was not found");
        salesList[index] = sale;
        Save(salesList);
    }

    private static List<Sale> Load()
    {
        if (!File.Exists(SALES_FILE_PATH))
            return new List<Sale>();

        XmlSerializer serializer = new(typeof(List<Sale>));
        using StreamReader sr = new(SALES_FILE_PATH);
        return serializer.Deserialize(sr) as List<Sale> ?? new List<Sale>();
    }

    private static void Save(List<Sale> salesList)
    {
        XmlSerializer serializer = new(typeof(List<Sale>));
        using StreamWriter sw = new(SALES_FILE_PATH);
        serializer.Serialize(sw, salesList);
    }
}
