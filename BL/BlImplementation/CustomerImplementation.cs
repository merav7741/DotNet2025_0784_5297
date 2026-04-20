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

        catch (DO.DalExsistException innerExeption)
        {
            throw new BO.BlIdExistsException("The customer is Exist!", innerExeption);
        }
    }
  
    public BO.Customer? Read(int id)
    {
        try
        {
            return (_dal.Customer.Read(id)).ConvertDoCustomerToBo();
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BLIdNotFoundException("לא נמצא לקוח עם מספר מזהה זה", ex);
        }
    }

    public List<BO.Customer> ReadAll(Func<BO.Customer, bool>? filter = null)
    {
        var list = _dal.Customer.ReadAll(null)
            .Select(c => c.ConvertDoCustomerToBo());

        if (filter != null)
            list = list.Where(filter);

        return list.ToList();
    }

    public void Update(BO.Customer item)
    {
        _dal.Customer.Update(item.ConvertBoCustomerToDo());
    }

    public void Delete(int id)
    {
        try
        {
            _dal.Customer.Delete(id);
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BLIdNotFoundException("לא נמצא לקוח עם מספר מזהה זה", ex);
        }
    }
    public BO.Customer? Read(Func<BO.Customer, bool>? filter)
    {
        try
        {
            var list = _dal.Customer.ReadAll(null)
                        .Select(c => c.ConvertDoCustomerToBo());

            return list.FirstOrDefault(filter);
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BlNotfoundObjectWithThisFilterException("לא נמצא לקוח שעונה על תנאי זה", ex);

        }
    }
    public bool IsExists(int id)
    {
        var list = _dal.Customer.ReadAll(null);
        return list.Any(c => c.Id == id);
    }

    public bool IsExist(int id)
    {
        throw new NotImplementedException();
    }
}