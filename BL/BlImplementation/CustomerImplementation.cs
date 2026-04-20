using BlApi;
using BO;
namespace BlImplementation;

internal class CustomerImplementation : ICustomer
{
    private readonly DalApi.IDal _dal = DalApi.Factory.Get;


    public int Create(BO.Customer item)
    {
        try
        {
            return _dal.Customer.Create(item.ConvertBoCustomerToDo());
        }
        catch (DO.DalExsistException ex)
        {
            throw new BO.BlAlreadyExistsException("Customer already exists", ex);
        }
        catch (Exception ex)
        {
            throw new BO.BlGeneralException("General error", ex);
        }
    }
    public BO.Customer? Read(int id)
    {
        try
        {
            var customer = _dal.Customer.Read(id);

            if (customer == null)
                throw new BO.BlDoesNotExistException($"Customer {id} not found");

            return customer.ConvertDoCustomerToBo();
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BlDoesNotExistException("Customer not found", ex);
        }
        catch (Exception ex)
        {
            throw new BO.BlGeneralException("General error", ex);
        }
    }

            if (customer == null)
                throw new BO.BlDoesNotExistException($"Customer {id} not found");

            return customer.ConvertDoCustomerToBo();
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BlDoesNotExistException("Customer not found", ex);
        }
        catch (Exception ex)
        {
            throw new BO.BlGeneralException("General error", ex);
        }
    }

    public BO.Customer? Read(Func<BO.Customer, bool>? filter)
    {
        if (filter == null) return null;
        return _dal.Customer.ReadAll().Select(c => c.ConvertDoCustomerToBo()).FirstOrDefault(filter);
    }

    public List<BO.Customer> ReadAll(Func<BO.Customer, bool>? filter = null)
    {
        var customers = _dal.Customer.ReadAll().Select(c => c.ConvertDoCustomerToBo());
        return filter == null ? customers.ToList() : customers.Where(filter).ToList();
    }

    public void Update(BO.Customer item) => _dal.Customer.Update(item.ConvertBoCustomerToDo());

    public void Delete(int id) => _dal.Customer.Delete(id);

    public bool IsExist(int id) => _dal.Customer.Read(id) != null;
}
