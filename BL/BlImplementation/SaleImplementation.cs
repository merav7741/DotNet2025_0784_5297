using System.Reflection;
using BlApi;
using BO;
using Tools;
namespace BlImplementation;

internal class SaleImplementation : ISale
{
    private readonly DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Sale item)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName
            , MethodBase.GetCurrentMethod().Name
            , "create sale");
            return _dal.Sale.Create(item.ConvertBoSaleToDo());
        }
        catch (Exception ex)
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Create {item} Sale Exeption: {ex.Message}");
            throw new BlIdExistsException("The sale is  Exist!");
        }
    }


    public BO.Sale? Read(int id)
    {
        try
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Read {id} Sale");
            return _dal.Sale.Read(id).ConvertDoSaleToBo();
        }
        catch
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Read {null} Sale");
            throw new BLIdNotFoundException("The sale is not Exist!");
        }
    }

    public BO.Sale? Read(Func<BO.Sale, bool>? filter)
    {
        try
        {
            DO.Sale sale = _dal.Sale.Read(s => filter(s.ConvertDoSaleToBo()));
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Read {sale} Sale");

            return sale.ConvertDoSaleToBo();
        }
        catch
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Read {null} Sale");
            throw new BLIdNotFoundException("The sale is not Exist!");
        }
    }

    public List<BO.Sale> ReadAll(Func<BO.Sale, bool>? filter = null)
    {
        try
        {
            if (filter == null)
                return _dal.Sale.ReadAll().Select(s => s.ConvertDoSaleToBo()).ToList();
            else
                return _dal.Sale.ReadAll(s => filter(s.ConvertDoSaleToBo())).Select(s => s.ConvertDoSaleToBo()).ToList();
        }
        catch
        {
            throw new BlIdExistsException("The sales are not  Exist!");
        }
    }

    public void Update(BO.Sale item)
    {
        try
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Update {item} Sale");
            _dal.Sale.Update(item.ConvertBoSaleToDo());
        }
        catch (BlIdExistsException ex)
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Update {item} Sale Exeption: {ex.Message}");
            throw new BlIdExistsException("The sale is  Exist!");
        }
    }

    public void Delete(int id)
    {
        try
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Delete {id} Sale");
            _dal.Sale.Delete(id);
        }
        catch (Exception ex)
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Delete {id} Sale Exepion: {ex.Message}");
            throw new BLIdNotFoundException("The sale is not Exist!");
        }
    }
}
