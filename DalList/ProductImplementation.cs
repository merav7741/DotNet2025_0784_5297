using Dal;
using DalApi;
using DO;
using static Dal.DataSource;

namespace Dal;
/// <summary>
/// מימוש מחלקות הגישה לנתונים
/// </summary>
internal class ProductImplementation : IProduct
{
    /// <summary>
    /// פונקצית הוספה-
    /// מוסיפה מוצר למערך המוצרים
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int Create(Product item)
    {
        for (int i = 0; i < DataSource.products.Count; i++)
        {
            if (DataSource.products[i] != null && DataSource.products[i].Id == item.Id)
            {
                throw new InvalidOperationException("לקוח זה כבר קיים ברשימת המוצרים");
            }
        }

        DataSource.products.Add(item);
        return item.Id;
    }

    /// <summary>
    /// פונקצית מחיקה-
    ///לפי ID מוחקת מוצר ממערך המוצרים
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        var productToDelete = DataSource.products.FirstOrDefault(product => product.Id == id);

        if (productToDelete == null)
        {
            throw new InvalidOperationException($"!!!מוצר זה לא נמצא");
        }

        DataSource.products.Remove(productToDelete);
    }
    /// <summary>
    /// פונקציה המקבלת ID ומחזירה את המוצר המבוקש
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Product? Read(int id)
    {
        foreach (Product product in DataSource.products)
        {
            if (product.Id == id)
                return product;
        }
        return null;
    }
    /// <summary>
    /// פונקציה המחזירה את מערך המוצרים
    /// </summary>
    /// <returns></returns>
    public List<Product> ReadAll()
    {
        return DataSource.products == null ? null : DataSource.products;
    }

    /// <summary>
    /// פונקציה המעדכנת מוצר מסוים
    /// </summary>
    /// <param name="item"></param>
    public void Update(Product item)
    {
        bool f = false;
        foreach (Product product in DataSource.products)
        {
            if (product.Id == item.Id)
            {
                f = true;
                DataSource.products.Remove(product);
            }
        }
        if (f)
        {
            DataSource.products.Add(item);
            return;
        }
        throw new Exception("לא נמצע מוצר זהה לעדכון");

    }
}

