using System.Xml.Serialization;
using DalApi;
using DO;

namespace Dal;

internal class ProductImplementation : IProduct
{
    private static readonly string PATH =
        Path.Combine(AppContext.BaseDirectory, "..", "xml", "products.xml");

    private static List<Product> Load()
    {
        EnsureDir();

        if (!File.Exists(PATH))
            return new List<Product>();

        try
        {
            XmlSerializer serializer = new(typeof(List<Product>));
            using StreamReader sr = new(PATH);
            return serializer.Deserialize(sr) as List<Product> ?? new List<Product>();
        }
        catch
        {
            return new List<Product>();
        }
    }

    private static void Save(List<Product> list)
    {
        EnsureDir();

        XmlSerializer serializer = new(typeof(List<Product>));
        using StreamWriter sw = new(PATH);
        serializer.Serialize(sw, list);
    }

    public int Create(Product item)
    {
        var list = Load();

        int id = Config.NextProductNum;
        Product newItem = item with { Id = id };

        list.Add(newItem);
        Save(list);

        return id;
    }

    public void Delete(int id)
    {
        var list = Load();

        var item = list.FirstOrDefault(x => x.Id == id)
            ?? throw new DalNotExistException("Product not found");

        list.Remove(item);
        Save(list);
    }

    public Product? Read(int id)
        => Load().FirstOrDefault(x => x.Id == id)
           ?? throw new DalNotExistException("Product not found");

    public Product? Read(Func<Product, bool> filter)
        => Load().FirstOrDefault(filter);

    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        var list = Load();
        return filter == null ? list.Cast<Product?>().ToList()
                              : list.Where(filter).Cast<Product?>().ToList();
    }

    public void Update(Product item)
    {
        var list = Load();

        int index = list.FindIndex(x => x.Id == item.Id);
        if (index == -1)
            throw new DalNotExistException("Product not found");

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