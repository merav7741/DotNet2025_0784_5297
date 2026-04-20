using BO;
using System.Diagnostics;
using Tools;

namespace BlTest;

internal class Program
{
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
    private static void Main(string[] args)
    {

        try
        {
            while (true)
            {
                int select1 = PrintMainMenu();
                switch (select1)
                {
                    case 1:
                        ProductMenu();
                        break;
                    case 2:
                        CustomerMenu();
                        break;
                    case 3:
                        SaleMenu();
                        break;
                    case 4:
                        LogManager.DeleteOldFolder();
                        break;
                    case 5:
                        OrderMenu();
                        break;
                    case 6:
                        DalTest.Initialization.Initialize();
                        break;
                    default:
                        return;

                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void OrderMenu()
    {
        BO.Order currentOrder = new BO.Order{ listProductInOrder = new List<BO.ProductInOrder>() };

        Console.WriteLine("Is this a preferred customer? (y/n)");
        currentOrder.isPreferedCustomer = Console.ReadLine()?.ToLower() == "y";

        while (true)
        {
            Console.WriteLine("--- Order Menu ---");
            Console.WriteLine("1. Add Product to Order");
            Console.WriteLine("2. Do Order (Finalize)");
            Console.WriteLine("3. Show Current Order Details");
            Console.WriteLine("0. Back to Main Menu");

            if (!int.TryParse(Console.ReadLine(), out int choice)) continue;
            if (choice == 0) return;

            try
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Product ID:");
                        int pId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Amount:");
                        int amount = int.Parse(Console.ReadLine());
                        var appliedSales = s_bl.Order.AddProductToOrder(currentOrder, pId, amount);
                        s_bl.Order.CalcTotalPrice(currentOrder);

                        Console.WriteLine("Product added successfully!");

                        if (appliedSales != null && appliedSales.Any())
                        {
                            Console.WriteLine("Special sales applied:");
                            appliedSales.ForEach(sale => Console.WriteLine($" * Applied Sale: {sale}"));
                        }
                        else
                        {
                            Console.WriteLine("No special sales for this product.");
                        }

                        Console.WriteLine($"Current Total: {currentOrder.finalPrice:C}");
                        break;

                    case 2:
                        if (!currentOrder.listProductInOrder.Any())
                        {
                            Console.WriteLine("Order is empty! Add products first.");
                            break;
                        }
                        s_bl.Order.DoOrder(currentOrder);
                        Console.WriteLine("Order completed successfully!");
                        return; 

                    case 3:
                        Console.WriteLine("\n--- Current Order Status ---");
                        Console.WriteLine(currentOrder);
                        break;
                }
            }
            catch (BlInputNotCorectException ex) 
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (BLThereIsNotEnoughInStock ex)
            {
                Console.WriteLine($"Inventory Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
        }
    }
    private static void ProductMenu()
    {
        while (true)
        {
            int select = PrintSubMenu("Product");
            switch (select)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    DeleteProduct();
                    break;
                case 3:
                    UpdateProduct();
                    break;
                case 4:
                    ReadProduct();
                    break;
                case 5:
                    ReadAllProducts();
                    break;
                default:
                    return; 
            }
        }
    }

    private static void CustomerMenu()
    {
        while (true)
        {
            int select = PrintSubMenu("Customer");
            switch (select)
            {
                case 1:
                    AddCustomer();
                    break;
                case 2:
                    DeleteCustomer();
                    break;
                case 3:
                    UpdateCustomer();
                    break;
                case 4:
                    ReadCustomer();
                    break;
                case 5:
                    ReadAllCustomers();
                    break;
                default:
                    return;
            }
        }
    }
    private static void SaleMenu()
    {
        while (true)
        {
            int select = PrintSubMenu("Sale");
            switch (select)
            {
                case 1:
                    AddSale();
                    break;
                case 2:
                    DeleteSale();
                    break;
                case 3:
                    UpdateSale();
                    break;
                case 4:
                    ReadSale();
                    break;
                case 5:
                    ReadAllSales();
                    break;
                default:
                    return;
            }
        }
    }

    private static Product AskProduct(int id = 0)
    {
        string productName;
        Categories category;
        double price;
        int stock;
        int cat;

        Console.WriteLine("enter product name");
        productName = Console.ReadLine();

        Console.WriteLine("Enter the category: between 0 to 4 ");
        if (!int.TryParse(Console.ReadLine(), out cat))
            category = 0;
        else
            category = (Categories)cat;

        Console.WriteLine("enetr price");
        double.TryParse(Console.ReadLine(), out price);

        Console.WriteLine("enter stock");
        int.TryParse(Console.ReadLine(), out stock);
        return new BO.Product
        {
            Id = id,
            Name = productName,
            Category = category,
            Price = price,
            CountStock = stock,
        };

    }
    private static Customer AskCustomer(int id = 0)
    {
        string customerName;
        string adress;
        string phone;

        Console.WriteLine("enter customer name");
        customerName = Console.ReadLine();
        Console.WriteLine("enter customer adress");
        adress = Console.ReadLine();
        Console.WriteLine("enter customer phone");
        phone = Console.ReadLine();

        return new BO.Customer
        {
            Id = id,
            Name = customerName,
            Address = adress,
            Phone = phone
        };
    }
    private static Sale AskSale(int id = 0)
    {
        int productId;
        int quantityRequier;
        double salePrice;
        bool isSaleToCustomer;
        DateTime startSale;
        DateTime endSale;

        Console.WriteLine("enter product id");
        int.TryParse(Console.ReadLine(), out productId);

        Console.WriteLine("enter quantity requier");
        int.TryParse(Console.ReadLine(), out quantityRequier);

        Console.WriteLine("enter sale price");
        double.TryParse(Console.ReadLine(), out salePrice);

        Console.WriteLine("enter is sale to customer");
        bool.TryParse(Console.ReadLine(), out isSaleToCustomer);

        Console.WriteLine("enter start sale date");
        DateTime.TryParse(Console.ReadLine(), out startSale);

        Console.WriteLine("enter end sale date");
        DateTime.TryParse(Console.ReadLine(), out endSale);

        return new BO.Sale
        {
            Id = id,
            ProductId = productId,
            QuantityForSale = quantityRequier,
            SalePrice = salePrice,
            IsSaleToAllCustomer = isSaleToCustomer,
            StartSale = startSale,
            EndSale = endSale
        };

    }
    private static void AddProduct()
    {
        try
        {
            Product product = AskProduct();
            int id = s_bl.Product.Create(product);
            Console.WriteLine($"Product added successfully! New ID: {id}");
        }
        catch (BlInputNotCorectException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (BlIdExistsException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General error: {ex.Message}");
        }
    }
    private static void AddCustomer()
    {
        try
        {
            Console.WriteLine("enter id");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new BlInputNotCorectException("ID must be a number!");
            }
            Customer customer = AskCustomer(id);
            s_bl.Customer.Create(customer);
            Console.WriteLine("created customer success!");
        }
        catch (BlInputNotCorectException ex)
        {
            Console.WriteLine($"Invalid input error: {ex.Message}");
        }
        catch (BlIdExistsException ex)
        {
            Console.WriteLine($"Logic error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
    private static void AddSale()
    {
        try
        {
            Sale sale = AskSale();
            int id = s_bl.Sale.Create(sale);
            Console.WriteLine($"Sale added successfully with ID: {id}");
        }
        catch (BLThereIsNotEnoughInStock ex)
        {
            Console.WriteLine($"Inventory Error: {ex.Message}");
        }
        catch (BLIdNotFoundException ex)
        {
            Console.WriteLine($"Reference Error: {ex.Message}");
        }
        catch (BlInputNotCorectException ex)
        {
            Console.WriteLine($"Input Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    private static void UpdateProduct()
    {
        try
        {
            Console.WriteLine("Enter the ID of the product you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new BlInputNotCorectException("ID must be a number!");

            Product product = AskProduct(id);

            s_bl.Product.Update(product);
            Console.WriteLine("Product updated successfully!");
        }
        catch (BLIdNotFoundException ex)
        {
            Console.WriteLine($"Update Error: {ex.Message}");
        }
        catch (BlInputNotCorectException ex)
        {
            Console.WriteLine($"Logic Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    private static void UpdateCustomer()
    {
        try
        {
            Console.WriteLine("Enter the ID of the customer you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new BlInputNotCorectException("ID must be a number!");
            Customer customer = AskCustomer(id);
            s_bl.Customer.Update(customer);
            Console.WriteLine("Customer updated successfully!");
        }
        catch (BLIdNotFoundException ex)
        {
            Console.WriteLine($"Update Error: {ex.Message}");
        }
        catch (BlInputNotCorectException ex)
        {
            Console.WriteLine($"Input Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void UpdateSale()
    {
        try
        {
            Console.WriteLine("Enter the ID of the sale record to update:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new BlInputNotCorectException("ID must be a number!");

            Sale sale = AskSale(id);

            s_bl.Sale.Update(sale);
            Console.WriteLine("Sale updated!");
        }
        catch (BLThereIsNotEnoughInStock ex)
        {
            Console.WriteLine($"Stock Error: {ex.Message}");
        }
        catch (BLIdNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ReadSale()
    {
        try
        {
            Console.WriteLine("Enter Sale ID to display:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new BlInputNotCorectException("ID must be a number!");

            var sale = s_bl.Sale.Read(id);
            Console.WriteLine("\n--- Sale Details ---");
            Console.WriteLine(sale);
        }
        catch (BLIdNotFoundException ex)
        {
            Console.WriteLine($"Search Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ReadAllSales()
    {
        try
        {
            var sales = s_bl.Sale.ReadAll();
            Console.WriteLine("\n--- All Sales History ---");
            foreach (var s in sales)
            {
                Console.WriteLine(s);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void DeleteSale()
    {
        try
        {
            Console.WriteLine("Enter Sale ID to delete:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new BlInputNotCorectException("ID must be a number!");

            s_bl.Sale.Delete(id);
            Console.WriteLine("Sale record removed.");
        }
        catch (BLIdNotFoundException ex)
        {
            Console.WriteLine($"Delete Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    private static void ReadProduct()
    {
        try
        {
            Console.WriteLine("Enter Product ID to display:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new BlInputNotCorectException("ID must be a number!");

            var product = s_bl.Product.Read(id);
            Console.WriteLine("\n--- Product Details ---");
            Console.WriteLine(product);
        }
        catch (BLIdNotFoundException ex)
        {
            Console.WriteLine($"Search Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ReadAllProducts()
    {
        try
        {
            var products = s_bl.Product.ReadAll();
            Console.WriteLine("\n--- All Products List ---");
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void DeleteProduct()
    {
        try
        {
            Console.WriteLine("Enter Product ID to delete:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new BlInputNotCorectException("ID must be a number!");

            s_bl.Product.Delete(id);
            Console.WriteLine("Product deleted successfully.");
        }
        catch (BLIdNotFoundException ex)
        {
            Console.WriteLine($"Delete Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ReadCustomer()
    {
        try
        {
            Console.WriteLine("Enter Customer ID to display:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new BlInputNotCorectException("ID must be a number!");

            var customer = s_bl.Customer.Read(id);
            Console.WriteLine("\n--- Customer Details ---");
            Console.WriteLine(customer);
        }
        catch (BLIdNotFoundException ex)
        {
            Console.WriteLine($"Search Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ReadAllCustomers()
    {
        try
        {
            var customers = s_bl.Customer.ReadAll();
            Console.WriteLine("--- All Customers List ---");
            foreach (var c in customers)
            {
                Console.WriteLine(c);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving customers: {ex.Message}");
        }
    }

    private static void DeleteCustomer()
    {
        try
        {
            Console.WriteLine("Enter Customer ID to delete:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new BlInputNotCorectException("ID must be a number!");

            s_bl.Customer.Delete(id);
            Console.WriteLine("Customer deleted successfully.");
        }
        catch (BLIdNotFoundException ex)
        {
            Console.WriteLine($"Delete Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    public static int PrintMainMenu()
    {
        int choice;
        Console.WriteLine("Product? press 1, Customer? press 2, Sale? press 3, delete from log? press 4, Order? press 5, exit? press another key, to initialisation press 6");
        return int.Parse(Console.ReadLine());
    }
    public static int PrintSubMenu(string item)
    {
        int choice;
        Console.WriteLine($"{item} menu: create - 1, delete - 2, update - 3, read - 4, read all - 5, exit - any key");
        int.TryParse(Console.ReadLine(), out choice);
        return choice;

    }

}
