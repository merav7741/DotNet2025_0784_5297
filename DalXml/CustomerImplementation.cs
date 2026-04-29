using System.Xml.Serialization;
using DalApi;
using DO;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    private static readonly string PATH =
        Path.Combine(AppContext.BaseDirectory, "xml", "customers.xml");

    private static List<Customer> Load()
    {
        EnsureDir();

        if (!File.Exists(PATH))
            return new List<Customer>();

        XmlSerializer serializer = new(typeof(List<Customer>));
        using StreamReader sr = new(PATH);
        return serializer.Deserialize(sr) as List<Customer> ?? new List<Customer>();
    }

    private static void Save(List<Customer> list)
    {
        EnsureDir();

        XmlSerializer serializer = new(typeof(List<Customer>));
        using StreamWriter sw = new(PATH);
        serializer.Serialize(sw, list);
    }

    public int Create(Customer item)
    {
        var list = Load();

        list.Add(item);
        Save(list);

        return item.Id;
    }

    public void Delete(int id)
    {
        var list = Load();

        var item = list.FirstOrDefault(x => x.Id == id)
            ?? throw new DalNotExistException("Customer not found");

        list.Remove(item);
        Save(list);
    }

    public Customer? Read(int id)
        => Load().FirstOrDefault(x => x.Id == id)
           ?? throw new DalNotExistException("Customer not found");

    public Customer? Read(Func<Customer, bool> filter)
        => Load().FirstOrDefault(filter);

    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        var list = Load();
        return filter == null ? list.Cast<Customer?>().ToList()
                              : list.Where(filter).Cast<Customer?>().ToList();
    }

    public void Update(Customer item)
    {
        var list = Load();

        int index = list.FindIndex(x => x.Id == item.Id);
        if (index == -1)
            throw new DalNotExistException("Customer not found");

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