using System.Linq;
using DalApi;
using DO;
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
        int newId = DataSource.Config.NextSaleId;
        Sale newSale = item with { Id = newId };
        DataSource.sales.Add(newSale);
        return newId;
    }

    /// <summary>
    /// פונקצית מחיקה-
    ///לפי ID מוחקת מבצע ממערך המבצעים
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        var saleToDelete = DataSource.sales.FirstOrDefault(sale => sale.Id == id);

        if (saleToDelete == null)
        {
            throw new DalNotExistException("This sale not exists in the sales list");
        }

        DataSource.sales.Remove(saleToDelete);
    }

    /// <summary>
    /// פונקציה המקבלת ID ומחזירה את המבצע המבוקש
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Sale? Read(int id)
    {
        var saleRead= DataSource.sales.FirstOrDefault(sale => sale.Id == id);
        if (saleRead == null)
            throw new DalNotExistException("this sale not exists in the sales list");
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
        var saleRead = DataSource.sales.FirstOrDefault(filter);
        if (saleRead == null)
            throw new DalNotExistException("Not Found sale with this filter in sales list");
        return saleRead;
    }

    /// <summary>
    /// פונקציה המחזירה את מערך המבצעים
    /// </summary>
    /// <returns></returns>
    public List<Sale> ReadAll()
    {
        return DataSource.sales == null ? null : new List<Sale>(DataSource.sales);
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
