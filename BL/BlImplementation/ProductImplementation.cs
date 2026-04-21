using System.Reflection;
using BlApi;
using BO;
using Tools;
namespace BlImplementation;

internal class ProductImplementation : IProduct
{
    private readonly DalApi.IDal _dal = DalApi.Factory.Get;
    /// <summary>
    /// פונקציה יצירת מוצר
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="BlIdExistsException"></exception>
    public int Create(BO.Product item)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName
            , MethodBase.GetCurrentMethod().Name
            , "create sale");
            return _dal.Product.Create(item.ConvertBoProductToDo());
        }
        catch (Exception ex)
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Create {item} Product Exeption: {ex.Message}");
            throw new BlIdExistsException("The Product is  Exist!");
        }
    }
    /// <summary>
    /// פונקציה המחזירה מוצר לפי ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="BLIdNotFoundException"></exception>
    public BO.Product? Read(int id)
    {
        try
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Read {id} Product");
            return _dal.Product.Read(id).ConvertDoProductToBo();
        }
        catch
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Read {id} Product  null");
            throw new BLIdNotFoundException("The product is not Exist!");
        }
    }
    /// <summary>
    /// פונקציה המחזירה מוצר לפי תנאי
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    /// <exception cref="BlNotfoundObjectWithThisFilterException"></exception>
    public BO.Product? Read(Func<BO.Product, bool>? filter)
    {
        try
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Read Product");
            return _dal.Product.Read(s => filter(s.ConvertDoProductToBo())).ConvertDoProductToBo();
        }
        catch
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Read Product  null");
            throw new BlNotfoundObjectWithThisFilterException("The product is not Exist!");
        }
    }
    /// <summary>
    /// פונקציה המחזירה את כל המוצרים שעונים על תנאי מסוים
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    /// <exception cref="BlNotfoundObjectWithThisFilterException"></exception>
    public List<BO.Product> ReadAll(Func<BO.Product, bool>? filter = null)
    {
        try
        {
            if (filter == null)
            {
                Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"ReadAll Product");
                return _dal.Product.ReadAll().Select(s => s.ConvertDoProductToBo()).ToList();
            }
            return _dal.Product.ReadAll(s => filter(s.ConvertDoProductToBo())).Select(s => s.ConvertDoProductToBo()).ToList();
        }
        catch
        {
            throw new BlNotfoundObjectWithThisFilterException("The products are not  Exist!");
        }
    }
    /// <summary>
    ///  פונקציה המעדכנת מוצר
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="BLIdNotFoundException"></exception>
    public void Update(BO.Product item)
    {
        try
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Update {item} Product");
            _dal.Product.Update(item.ConvertBoProductToDo());
        }
        catch (Exception ex)
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Update {item} Product  Exeption: {ex.Message}");
            throw new BLIdNotFoundException("The product is not Exist!");
        }
    }
    /// <summary>
    ///  פונקציה המוחקת מוצר לפי ID
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="BLIdNotFoundException"></exception>
    public void Delete(int id)
    {
        try
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Delete {id} Product");
            _dal.Product.Delete(id);
        }
        catch (Exception ex)
        {
            Tools.LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Delete {id} Product  Exception: {ex.Message}");
            throw new BLIdNotFoundException("The product is not  Exist!");
        }
    }

    /// <summary>
    ///  פונקציה המחזירה את ההמנות של התאריך
    /// </summary>
    /// <param name="productInOrder"></param>
    /// <param name="isPreferedCus"></param>
    public void AllSalesInDate(BO.ProductInOrder productInOrder, bool isPreferedCus)
    {
        try
        {
            var sales = _dal.Sale
           .ReadAll()
           .Where(s => s.ProductId == productInOrder.idProductInOrder)
           .Where(s => (!s.StartSale.HasValue || s.StartSale.Value <= DateTime.Now) && (!s.EndSale.HasValue || s.EndSale.Value >= DateTime.Now))
         .Where(s => !s.QuantityForSale.HasValue || s.QuantityForSale.Value <= productInOrder.amountProductInOrder)
         .Where(s => isPreferedCus || s.IsSaleToAllCustomer)
         .Select(s => s.ConvertDoSaleToSaleInProduct())
         .OrderBy(s => s.amountSaleInProduct == 0 ? double.MaxValue : s.priceSaleInProduct / s.amountSaleInProduct)
         .ToList();
            productInOrder.listSaleToProductInOrder = sales;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
