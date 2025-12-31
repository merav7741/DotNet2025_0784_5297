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
        for (int i = 0; i < DataSource.sales.Count; i++)
        {
            if (DataSource.sales[i] != null && DataSource.sales[i].Id == item.Id)
            {
                throw new InvalidOperationException("לקוח זה כבר קיים ברשימת מכירות");
            }
        }

        DataSource.sales.Add(item);
        return item.Id;
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
            throw new InvalidOperationException($"!!!מבצע זה לא נמצא");
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
        foreach (Sale sale in DataSource.sales)
        {
            if (sale.Id == id)
                return sale;
        }
        return null;
    }

    /// <summary>
    /// פונקציה המחזירה את מערך המבצעים
    /// </summary>
    /// <returns></returns>
    public List<Sale> ReadAll()
    {
        return DataSource.sales == null ? null : DataSource.sales;
    }

    /// <summary>
    /// פונקציה עדכון-
    /// פונקציה המעדכנת מבצע מסוים
    /// </summary>
    /// <param name="item"></param>
    public void Update(Sale item)
    {
        bool f = false;
        foreach (Sale sale in DataSource.sales)
        {
            if (sale.Id == item.Id)
            {
                f = true;
                DataSource.sales.Remove(sale);
            }
        }
        if (f)
        {
            DataSource.sales.Add(item);
            return;
        }
        throw new Exception("לא נמצע מבצע זהה לעדכון");
    }
}
