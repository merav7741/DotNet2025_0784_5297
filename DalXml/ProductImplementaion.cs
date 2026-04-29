using DalApi;
using DO;
using System.Xml.Serialization;

namespace Dal;

internal class ProductImplementation : IProduct
{
    // שימוש בניתוב בטוח ויחסי שמתאים לכל מחשב

   private static readonly string PATH = Path.Combine(AppContext.BaseDirectory, "..", "xml", "products.xml");

    private readonly XmlSerializer serializer = new(typeof(List<Product>));
    private List<Product>? products;

    private List<Product> LoadList()
    {
        // בדיקה ויצירה של התיקייה במידה והיא לא קיימת בתיקיית ה-Debug
        string? dir = Path.GetDirectoryName(PATH);
        if (dir != null && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        if (!File.Exists(PATH))
            return new List<Product>();

        try
        {
            using StreamReader sr = new StreamReader(PATH);
            return serializer.Deserialize(sr) as List<Product> ?? new List<Product>();
        }
        catch
        {
            // אם הקובץ פגום, נחזיר רשימה ריקה
            return new List<Product>();
        }
    }

    private void SaveList(List<Product> list)
    {
        using StreamWriter sw = new StreamWriter(PATH);
        serializer.Serialize(sw, list);
    }

    public int Create(Product item)
    {
        products = LoadList();

        int newId = Config.NextProductNum;
        Product newItem = item with { Id = newId };

        if (products.Any(p => p.Id == newItem.Id))
            throw new DalExsistException("Product already exists");

        products.Add(newItem);
        SaveList(products);

        return newItem.Id;
    }

    public Product? Read(int id)
    {
        products = LoadList();

        Product? product = products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            throw new DalNotExistException("Product not exists");

        return product;
    }

    public Product? Read(Func<Product, bool> filter)
    {
        products = LoadList();
        return products.FirstOrDefault(p => filter(p));
    }

    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        products = LoadList();

        return filter == null
            ? new List<Product>(products)
            : products.Where(filter).ToList();
    }

    public void Update(Product item)
    {
        products = LoadList();

        int index = products.FindIndex(p => p.Id == item.Id);

        if (index < 0)
            throw new DalNotExistException("Product not exists");

        products[index] = item;

        SaveList(products);
    }

    public void Delete(int id)
    {
        products = LoadList();

        Product? product = products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            throw new DalNotExistException("Product not exists");

        products.Remove(product);
        SaveList(products);
    }
}