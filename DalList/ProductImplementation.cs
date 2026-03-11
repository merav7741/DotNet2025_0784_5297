using System.Collections.Generic;
using System.Reflection;
using Dal;
using DalApi;
using DO;
using Tools;
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
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start create new product");
        int newId = DataSource.Config.NextProduct;
        Product newProduct = item with { Id = newId };
        DataSource.products.Add(newProduct);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end create new product succesfull");
        return newId;
    }
    /// <summary>
    /// פונקצית מחיקה-
    ///לפי ID מוחקת מוצר ממערך המוצרים
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start delete  product");
        var productToDelete = DataSource.products.FirstOrDefault(product => product.Id == id);
        if (productToDelete == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "Eror cant delete the product because  id not exists");
            throw new DalNotExistException("The product not exists in products list");
        }
        DataSource.products.Remove(productToDelete);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end delete product succesfull");
    }
    /// <summary>
    /// פונקציה המקבלת ID ומחזירה את המוצר המבוקש
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Product Read(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start read with id product");
        var productRead = DataSource.products.FirstOrDefault(product => product.Id == id);
        if (productRead == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "Eror cant read  product because  not found customer with this filter");
            throw new DalNotExistException("The product not exists in products list");
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end read with id product succesfull");
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
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start read with filter product");
        var productRead = DataSource.products.FirstOrDefault(C => filter(C!));
        if (productRead == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "Eror cant read with filter  product because  not found product with this filter");
            throw new DalNotExistException("Not Found product with this filter in products list");
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "Eror cant read with filter product succesfull");
        return productRead;
    }
    /// <summary>
    /// פונקציה המחזירה את מערך המוצרים
    /// </summary>
    /// <returns></returns>
    public List<Product?> ReadAll(Func<Product, bool>? filter)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start read all product");
        if (filter == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end read all product return full products list becausu the filter is null");
            return new List<Product?>(DataSource.products);
        }
        var product = DataSource.products.Where(p => filter(p!));
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end read all product succesfull");
        return product.ToList();
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

