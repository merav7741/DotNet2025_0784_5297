using System.Xml.Serialization;
using DalApi;
using DO;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    private const string CUSTOMERS_FILE_PATH = "../xml/customers.xml";

    public int Create(Customer c)
    {
        List<Customer> customersList = Load();
        if (customersList.Any(cus => cus.Id == c.Id))
            throw new DalExsistException($"Customer with id: {c.Id} already exists");
        customersList.Add(c);
        Save(customersList);
        return c.Id;
    }

    public void Delete(int id)
    {
        List<Customer> customersList = Load();
        Customer? customer = customersList.FirstOrDefault(cus => cus.Id == id);
        if (customer == null)
            throw new DalNotExistException($"Customer with id: {id} was not found");
        customersList.Remove(customer);
        Save(customersList);
    }

    public Customer? Read(int id)
    {
        return Load().FirstOrDefault(cus => cus.Id == id) ?? throw new DalNotExistException($"Customer with id: {id} was not found");
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        return Load().FirstOrDefault(filter);
    }

    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        List<Customer> customersList = Load();
        return filter == null ? customersList : customersList.Where(filter).ToList();
    }

    public void Update(Customer c)
    {
        List<Customer> customersList = Load();
        int index = customersList.FindIndex(cus => cus.Id == c.Id);
        if (index < 0)
            throw new DalNotExistException($"Customer with id: {c.Id} was not found");
        customersList[index] = c;
        Save(customersList);
    }

    private static List<Customer> Load()
    {
        XmlSerializer serializer = new(typeof(List<Customer>));
        using StreamReader sr = new(CUSTOMERS_FILE_PATH);
        return serializer.Deserialize(sr) as List<Customer> ?? new List<Customer>();
    }

    private static void Save(List<Customer> customersList)
    {
        XmlSerializer serializer = new(typeof(List<Customer>));
        using StreamWriter sw = new(CUSTOMERS_FILE_PATH);
        serializer.Serialize(sw, customersList);
    }
}
