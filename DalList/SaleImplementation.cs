using System.Linq;
using System.Reflection;
using DalApi;
using DO;
using Tools;
using static Dal.DataSource;

namespace Dal;

internal class SaleImplementation : ISale
{
    /// <summary>
    /// פונקצית הוספה-
    /// מוסיפה מבצע למערך המבצעים
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int Create(Sale item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start create new sale");
        int newId = DataSource.Config.NextSaleId;
        Sale newSale = item with { Id = newId };
        DataSource.sales.Add(newSale);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end create new sale succesfull");
        return newId;
    }
    /// <summary>
    /// פונקצית מחיקה-
    ///לפי ID מוחקת מבצע ממערך המבצעים
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start delete sale");
        var saleToDelete = DataSource.sales.FirstOrDefault(sale => sale.Id == id);
        if (saleToDelete == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "Eror cant delete the sale because  id not exists");
            throw new DalNotExistException("This sale not exists in the sales list");
        }
        DataSource.sales.Remove(saleToDelete);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end delete sale succesfull");

    }
    /// <summary>
    /// פונקציה המקבלת ID ומחזירה את המבצע המבוקש
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Sale? Read(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start read with id sale");
        var saleRead = DataSource.sales.FirstOrDefault(sale => sale.Id == id);
        if (saleRead == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "Eror cant read  sale because  not found customer with this filter");
            throw new DalNotExistException("this sale not exists in the sales list");
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end read with id sale succesfull");
        return saleRead;
    }
    /// <summary>
    /// פוקציה קריאה לפי תנאי מסוים
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    /// <exception cref="DalNotExistException"></exception>
    public Sale? Read(Func<Sale, bool> filter)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start read with filter sale");
        var saleRead = DataSource.sales.FirstOrDefault(filter);
        if (saleRead == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "Eror cant read with filter sale because not found sale with this filter");
            throw new DalNotExistException("Not Found sale with this filter in sales list");
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end read with filter sale succesfull");
        return saleRead;
    }

    /// <summary>
    /// פונקציה המחזירה את מערך המבצעים
    /// </summary>
    /// <returns></returns>
    public List<Sale?> ReadAll(Func<Sale, bool>? filter)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start read all sale");
        if (filter == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end read all sale return full sales list becausu the filter is null");
            return new List<Sale?>(DataSource.sales);
        }
        var sale = DataSource.sales.Where(p => filter(p!));
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end read all sale succesfull");
        return sale.ToList();

    }
    /// <summary>
    /// פונקציה עדכון-
    /// פונקציה המעדכנת מבצע מסוים
    /// </summary>
    /// <param name="item"></param>
    public void Update(Sale item)
    {
        if (DataSource.sales.Any(c => c?.Id == item.Id))
        {
            Delete(item.Id);
        }
        DataSource.sales.Add(item);
    }
}
