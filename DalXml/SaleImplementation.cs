using System.Xml.Serialization;
using DalApi;
using DO;

namespace Dal;

internal class SaleImplementation : ISale
{
    private static readonly string SALES_FILE_PATH = Path.Combine(AppContext.BaseDirectory, "..", "xml", "sales.xml");


    public int Create(Sale s)
    {
        int myId = Config.NextSaleNum;
        s = s with { Id = myId };

        List<Sale> salesList = Load();

        if (salesList.Any(x => x.Id == s.Id))
            throw new DalExsistException($"Sale with id: {s.Id} already exists");

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
        return salesList.FirstOrDefault(x => x.Id == id)
               ?? throw new DalNotExistException($"Sale with id: {id} was not found");
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

    // פונקציית טעינה בטוחה באמצעות XmlSerializer
    private static List<Sale> Load()
    {
        // יצירת התיקייה במידה והיא לא קיימת ב-Debug
        string? dir = Path.GetDirectoryName(SALES_FILE_PATH);
        if (dir != null && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        if (!File.Exists(SALES_FILE_PATH))
            return new List<Sale>();

        try
        {
            XmlSerializer serializer = new(typeof(List<Sale>));
            using StreamReader sr = new(SALES_FILE_PATH);
            return serializer.Deserialize(sr) as List<Sale> ?? new List<Sale>();
        }
        catch
        {
            // אם הקובץ פגום או ריק, נחזיר רשימה חדשה
            return new List<Sale>();
        }
    }

    // פונקציית שמירה בטוחה
    private static void Save(List<Sale> salesList)
    {
        XmlSerializer serializer = new(typeof(List<Sale>));
        using StreamWriter sw = new(SALES_FILE_PATH);
        serializer.Serialize(sw, salesList);
    }
}