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
        int newId = DataSource.Config.NextProduct;
        foreach (Product? product in DataSource.products)
        {
            if (product != null && product!.Id == item.Id)
            {
                throw new Exception("The product exists in the list");
            }
        }
        Product newProduct = item with { Id = newId };
        DataSource.products.Add(newProduct);
        return newId;
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
        if (DataSource.products.Any(c => c?.Id == item.Id))
        {
            Delete(item.Id);
        }
        DataSource.products.Add(item);
    }
}

