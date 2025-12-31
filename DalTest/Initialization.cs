using DO;
using DalApi; // Ensure you have the correct interface namespaces

namespace DalTest;

public static class Initialization
{
   /// <summary>
   /// רשימה סטטית שתכיל את רשימות הנתונים
   /// </summary>
    private static IDal s_dal;

    /// <summary>
    /// פונקציה סטטית  שמייצרת מוצרים
    /// </summary>
    private static void CreateProducts()
    {
        
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
        s_dal.Sale.Create(new Sale(1, 1, 1, 150, true, DateTime.Now, DateTime.Now.AddDays(7)));
        s_dal.Sale.Create(new Sale(2, 2, 2, 50, true, DateTime.Now, DateTime.Now.AddDays(10)));
        s_dal.Sale.Create(new Sale(3, 3, 4, 60, true, DateTime.Now, DateTime.Now.AddDays(14)));
        s_dal.Sale.Create(new Sale(4, null, 3,70 , true, DateTime.Now, DateTime.Now.AddDays(10)));
        s_dal.Sale.Create(new Sale(5, null, 2, 120, true, DateTime.Now, DateTime.Now.AddDays(10)));
    }

  
    public static void Initialize(IDal dal)
    {
        s_dal= dal;

        CreateProducts();
        CreateCustomers();
        CreateSales();
    }
}
