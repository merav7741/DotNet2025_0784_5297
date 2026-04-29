using System.Xml.Serialization;
using DalApi;
using DO;

namespace Dal;

internal class SaleImplementation : ISale
{
    private static readonly string PATH =
        Path.Combine(AppContext.BaseDirectory, "..", "xml", "sales.xml");

    private static List<Sale> Load()
    {
        EnsureDir();

        if (!File.Exists(PATH))
            return new List<Sale>();

        try
        {
            XmlSerializer serializer = new(typeof(List<Sale>));
            using StreamReader sr = new(PATH);
            return serializer.Deserialize(sr) as List<Sale> ?? new List<Sale>();
        }
        catch
        {
            return new List<Sale>();
        }
    }

    private static void Save(List<Sale> list)
    {
        EnsureDir();

        XmlSerializer serializer = new(typeof(List<Sale>));
        using StreamWriter sw = new(PATH);
        serializer.Serialize(sw, list);
    }

    public int Create(Sale item)
    {
        var list = Load();

        int id = Config.NextSaleNum;
        Sale newItem = item with { Id = id };

        list.Add(newItem);
        Save(list);

        return id;
    }

    public void Delete(int id)
    {
        var list = Load();

        var item = list.FirstOrDefault(x => x.Id == id)
            ?? throw new DalNotExistException("Sale not found");

        list.Remove(item);
        Save(list);
    }

    public Sale? Read(int id)
        => Load().FirstOrDefault(x => x.Id == id)
           ?? throw new DalNotExistException("Sale not found");

    public Sale? Read(Func<Sale, bool> filter)
        => Load().FirstOrDefault(filter);

    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        var list = Load();
        return filter == null ? list.Cast<Sale?>().ToList()
                              : list.Where(filter).Cast<Sale?>().ToList();
    }

    public void Update(Sale item)
    {
        var list = Load();

        int index = list.FindIndex(x => x.Id == item.Id);
        if (index == -1)
            throw new DalNotExistException("Sale not found");

        list[index] = item;
        Save(list);
    }

    private static void EnsureDir()
    {
        var dir = Path.GetDirectoryName(PATH);
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir!);
    }
}