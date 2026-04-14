using DO;
using DalApi; // Ensure you have the correct interface namespaces

namespace DalTest;

public static class Initialization
{  
   /// <summary>
   /// רשימה סטטית שתכיל את רשימות הנתונים
   /// </summary>
    private static IDal s_dal;
    private static List<int> lst = new List<int>();

    /// <summary>
    /// פונקציה סטטית  שמייצרת מוצרים
    /// </summary>
    private static void CreateProducts()
    {
        lst.Add(s_dal.Product.Create(new Product(1, "Heart necklace", DO.Categories.Necklace, 120, 20)));
        lst.Add(s_dal.Product.Create(new Product(2, "Heart Bracelet", DO.Categories.Bracelet, 80, 10)));
        lst.Add(s_dal.Product.Create(new Product(3, "Hoop earring", DO.Categories.Earring, 90, 34)));
        lst.Add(s_dal.Product.Create(new Product(4, "Gold watch", DO.Categories.Watch, 350, 3)));
        lst.Add(s_dal.Product.Create(new Product(5, "Pandora ring", DO.Categories.Ring, 110, 12)));
    }


    /// <summary>
    /// פונקציה סטטית  שמייצרת לקוחות
    /// </summary>
    private static void CreateCustomers()
    {
        s_dal.Customer.Create(new Customer(1, "Yosef Chaim Levi", "Bnei Brack", "0583256857"));
        s_dal.Customer.Create(new Customer(2, "Yael Gershon", "Modiin", "0556784421"));
        s_dal.Customer.Create(new Customer(3, "Rachel Kuk", "Address A", "0533104085"));
        s_dal.Customer.Create(new Customer(4, "Noa Tut", "Jerushalem", "0533127859"));
        s_dal.Customer.Create(new Customer(5, "Michal Vi", "Haifa", "0534128596"));
        s_dal.Customer.Create(new Customer(6, "Lea Booksan", "BEitar", "0556784586"));
    }

    /// <summary>
    /// פונקציה סטטית  שמייצרת מכירות
    /// </summary>
    private static void CreateSales()
    {
        s_dal.Sale.Create(new Sale(1, lst[0], 1, 150, true, DateTime.Now, DateTime.Now.AddDays(7)));
        s_dal.Sale.Create(new Sale(2, lst[1], 2, 50, true, DateTime.Now, DateTime.Now.AddDays(10)));
        s_dal.Sale.Create(new Sale(3, lst[2], 4, 60, true, DateTime.Now, DateTime.Now.AddDays(14)));
        s_dal.Sale.Create(new Sale(4, lst[3], 3, 70, true, DateTime.Now, DateTime.Now.AddDays(10)));
        s_dal.Sale.Create(new Sale(5, lst[4], 2, 120, true, DateTime.Now, DateTime.Now.AddDays(10)));
    }


    public static void Initialize(IDal dal)
    {
        s_dal = DalApi.Factory.Get;

        CreateProducts();
        CreateCustomers();
        CreateSales();
    }
}
