using BlApi;
using BO;

namespace BlImplementation;

internal class CustomerImplementation : ICustomer
{
    private readonly DalApi.IDal _dal = DalApi.Factory.Get;

   
    public int Create(BO.Customer item)
    {
        return _dal.Customer.Create(item.ConvertBoCustomerToDo());
    }
    public BO.Customer? Read(int id)
    {
        var customer = _dal.Customer.Read(id);
        return customer?.ConvertDoCustomerToBo();
    }

    public List<BO.Customer> ReadAll(Func<BO.Customer, bool>? filter = null)
    {
        var customers = _dal.Customer
            .ReadAll()
            .Select(c => c.ConvertDoCustomerToBo());

        return filter == null
            ? customers.ToList()
            : customers.Where(filter).ToList();
    }

    public void Update(BO.Customer item)
    {
        _dal.Customer.Update(item.ConvertBoCustomerToDo());
    }

    public void Delete(int id)
    {
        _dal.Customer.Delete(id);
    }

    public BO.Customer? Read(Func<BO.Customer, bool>? filter)
    {
        if (filter == null)
            return null;

        return _dal.Customer
            .ReadAll()
            .Select(c => c.ConvertDoCustomerToBo())
            .FirstOrDefault(filter);
    }

    public bool IsExist(int id)
    {
        return _dal.Customer.Read(id) != null;
    }
}