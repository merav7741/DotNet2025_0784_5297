using System.Collections.Generic;
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
            throw new DalNotExistException("The product not exists in products list");
        }

        DataSource.products.Remove(productToDelete);
    }
    /// <summary>
    /// פונקציה המקבלת ID ומחזירה את המוצר המבוקש
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Product Read(int id)
    {
        var productRead = DataSource.products.FirstOrDefault(product => product.Id == id);
        if (productRead == null)
            throw new DalNotExistException("The product not exists in products list");
        return productRead;
    }
    /// <summary>
    /// פוקציה קריאה לפי תנאי מסוים
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    /// <exception cref="DalNotExistException"></exception>
    public Product? Read(Func<Product, bool> filter)
    {
        var productRead = DataSource.products.FirstOrDefault(filter);
        if (productRead == null)
            throw new DalNotExistException("Not Found product with this filter in products list");
        return productRead;
    }

    /// <summary>
    /// פונקציה המחזירה את מערך המוצרים
    /// </summary>
    /// <returns></returns>
    public List<Product> ReadAll()
    {
        return DataSource.products == null ? null :new List<Product>( DataSource.products);
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

