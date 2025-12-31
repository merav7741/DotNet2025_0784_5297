using DO;
using DalApi; // Ensure you have the correct interface namespaces

namespace DalTest;

public static class Initialization
{
    // Static fields for each interface
    private static IProduct s_dalProduct;
    private static ICustomer s_dalCustomer;
    private static ISale s_dalSale;

    // Private methods to create entries
    private static void CreateProducts()
    {
        s_dalProduct.Create(new Product(1, "Product A", Categories.Earring, 29.99, 100));
        s_dalProduct.Create(new Product(2, "Product B", Categories.Necklace, 49.99, 50));
        // Add more products as needed
    }

    private static void CreateCustomers()
    {
        s_dalCustomer.Create(new Customer(1, "Customer A", "Address A", "1234567890"));
        s_dalCustomer.Create(new Customer(2, "Customer B", "Address B", "0987654321"));
        // Add more customers as needed
    }

    private static void CreateSales()
    {
        s_dalSale.Create(new Sale(1, 1, 5, 124.95, true, DateTime.Now, DateTime.Now.AddDays(7)));
        // Add more sales as needed
    }

    // Public method to initialize the lists
    public static void Initialize(IProduct productDal, ICustomer customerDal, ISale saleDal)
    {
        s_dalProduct = productDal;
        s_dalCustomer = customerDal;
        s_dalSale = saleDal;

        CreateProducts();
        CreateCustomers();
        CreateSales();
    }
}
