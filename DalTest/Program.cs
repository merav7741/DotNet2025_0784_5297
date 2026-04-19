using DalApi;
using DO;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Reflection;
using Tools;


namespace DalTest

{
    /// <summary>`
    /// מחלקת התוכנית הראשית
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// מופע של Dal לגישה לנתונים
        /// </summary>
        //static readonly IDal s_dal = new Dal.DalList();
        //שגיאה לבדוק איך מגדירים?
     
        //private?
        static readonly DalApi.IDal s_dal = DalApi.Factory.Get;


        private static void Main(string[] args)
        {
            try
            {
                int choice;
                Initialization.Initialize();
                while ((choice = PrintMainMenu()) != 0)
                {
                    switch (choice)
                    {
                        case 1:
                            ProductMenu();
                            break;
                        case 2:
                            SaleMenu();
                            break;
                        case 3:
                            CustomerMenu();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "Error: Unable to create store lists . ");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        /// <summary>
        /// פונקציה לתפריט הראשי
        /// </summary>
        /// <returns></returns>
        public static int PrintMainMenu()
        {
            int choice;
            Console.WriteLine("Main Menu: 1 - Product 2 - Sales 3 - Customers 0 - Exit");
            int.TryParse(Console.ReadLine(), out choice);
            return choice;
        }
        /// <summary>
        /// פונקציה לתפריט המשני
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int PrintSubMenu(string item)
        {
            int choice;
            Console.WriteLine($"{item} Menu: 1 - Add 2 - Update 3 - Read 4- Read All 5 - Delete 0 - Back");
            int.TryParse(Console.ReadLine(), out choice);
            return choice;
        }
        /// <summary>
        /// פונקציה לתפריט מוצרים
        /// </summary>
        public static void ProductMenu()
        {
            int choice;
            do
            {
                choice = PrintSubMenu("product");
                switch (choice)
                {
                    case 1:
                        AddProduct();
                        break;
                    case 2:
                        UpdateProduct();
                        break;
                    case 3:
                        Read(s_dal.Product!);
                        break;
                    case 4:
                        ReadAll(s_dal.Product!);
                        break;
                    case 5:
                        Delete(s_dal.Product);
                        break;


                }

            } while (choice != 0);

        }
        /// <summary>
        ///  פונקציה לתפריט לקוחות
        /// </summary>
        public static void CustomerMenu()
        {
            int choice;
            do
            {
                choice = PrintSubMenu("customer");
                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        UpdateCustomer();
                        break;
                    case 3:
                        Read(s_dal.Customer!);
                        break;
                    case 4:
                        ReadAll(s_dal.Customer!);
                        break;
                    case 5:
                        Delete(s_dal.Customer!);
                        break;
                }

            } while (choice != 0);

        }
        /// <summary>
        /// פונקציה לתפריט מכירות
        /// </summary>
        public static void SaleMenu()
        {
            int choice;
            do
            {
                choice = PrintSubMenu("sale");
                switch (choice)
                {
                    case 1:
                        AddSale();
                        break;
                    case 2:
                        UpdateSale();
                        break;
                    case 3:
                        Read(s_dal.Sale!);
                        break;
                    case 4:
                        ReadAll(s_dal.Sale!);
                        break;
                    case 5:
                        Delete(s_dal.Sale!);
                        break;
                }

            } while (choice != 0);

        }
        /// <summary>
        /// פונקציה לקריאת פריט מסוג T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="crud"></param>
        private static void Read<T>(ICrud<T> crud)
        {
            Console.WriteLine("insert id");
            try
            {
                Console.WriteLine(crud.Read(int.Parse(Console.ReadLine() ?? "")));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        /// <summary>
        /// פונקציה לקריאת כל הפריטים מסוג T    
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="icrud"></param>
        private static void ReadAll<T>(ICrud<T> icrud)
        {
            foreach (T item in icrud.ReadAll())
                if (item != null)
                    Console.WriteLine(item);
        }
        /// <summary>
        /// פונקציה למחיקת פריט מסוג T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="crud"></param>
        private static void Delete<T>(ICrud<T> crud)
        {
            Console.WriteLine("insert id to remove");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                crud.Delete(id);
                Console.WriteLine("this is remove");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
            }
        }

        /// <summary>
        /// פונקציה להוספת מכירה
        /// </summary>
        private static void AddSale()
        {
            Sale sale = AskSale();
            int newId = s_dal.Sale.Create(sale);
            Console.WriteLine($"Sale added with Id: {newId}");
        }
        /// <summary>
        /// פונקציה להוספת לקוח
        /// </summary>
        private static void AddCustomer()
        {
            Customer customer = AskCustomer();
            int newId = s_dal.Customer.Create(customer);
            Console.WriteLine($"Customer added with Id: {newId}");
        }
        /// <summary>
        /// פונקציה להוספת מוצר
        /// </summary>
        private static void AddProduct()
        {
            Product product = AskProduct();
            int newId = s_dal.Product.Create(product);
            Console.WriteLine($"Product added with Id: {newId}");
        }
        /// <summary>
        /// פונקציה לעדכון מוצר
        /// </summary>
        private static void UpdateProduct()
        {
            Console.WriteLine("insert id for update product");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int id))
            {
                Product product = AskProduct(id);
                s_dal.Product.Update(product);
                Console.WriteLine("product updated");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
            }
        }
        /// <summary>
        /// פונקציה לעדכון מכירה
        /// </summary>
        private static void UpdateSale()
        {
            Console.WriteLine("insert id for update sale");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int id))
            {
                Sale sale = AskSale(id);
                s_dal.Sale.Update(sale);
                Console.WriteLine("sale updated");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
            }
        }
        /// <summary>
        /// פונקציה לעדכון לקוח
        /// </summary>
        private static void UpdateCustomer()
        {
            Console.WriteLine("insert id for update customer");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int id))
            {
                Customer customer = AskCustomer(id);
                s_dal.Customer.Update(customer);
                Console.WriteLine("customer updated");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
            }

        }
        /// <summary>
        /// פונקציה לשאילת פרטי מוצר מהמשתמש
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static Product AskProduct(int code = 0)
        {
            string name;
            Categories category;
            double price;
            int count;
            Console.WriteLine("Enter the Name of the product");
            name = Console.ReadLine();
            Console.WriteLine("Enter the category: between 0 to 3 ");
            int cat;
            if (!int.TryParse(Console.ReadLine(), out cat)) category = 0;
            else
                category = Categories.Earring;
            Console.WriteLine("Enter Price");
            if (!double.TryParse(Console.ReadLine(), out price)) price = 10;
            Console.WriteLine("Enter count in stock");
            if (!int.TryParse(Console.ReadLine(), out count)) count = 0;
            return new Product(code, name, category, price, count);
        }
        /// <summary>
        /// פונקציה לשאילת פרטי מכירה מהמשתמש
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static Sale AskSale(int code = 0)
        {
            int ProductId;
            int QuantityForSale;
            double SalePrice;
            bool IsSaleToAllCustomer;
            DateTime StartSale;
            DateTime EndSale;
            Console.WriteLine("Enter the ProductId of the sale");
            if (!int.TryParse(Console.ReadLine(), out ProductId)) ProductId = 0;
            Console.WriteLine("Enter the QuantityForSale of the sale");
            if (!int.TryParse(Console.ReadLine(), out QuantityForSale)) QuantityForSale = 0;
            Console.WriteLine("Enter SalePrice");
            if (!double.TryParse(Console.ReadLine(), out SalePrice)) SalePrice = 0;
            Console.WriteLine("Is Sale To All Customer? true/false");
            if (!bool.TryParse(Console.ReadLine(), out IsSaleToAllCustomer)) IsSaleToAllCustomer = true;
            Console.WriteLine("Enter StartSale date (yyyy-MM-dd) or leave empty");
            string startInput = Console.ReadLine();
            if (!DateTime.TryParse(startInput, out StartSale)) StartSale = DateTime.MinValue;
            Console.WriteLine("Enter EndSale date (yyyy-MM-dd) or leave empty");
            string endInput = Console.ReadLine();
            if (!DateTime.TryParse(endInput, out EndSale)) EndSale = DateTime.Now;
            return new Sale(code, ProductId, QuantityForSale, SalePrice, IsSaleToAllCustomer,
                StartSale == DateTime.MinValue ? null : StartSale,
                EndSale == DateTime.Now ? null : EndSale);
        }
        /// <summary>
        /// פונקציה לשאילת פרטי לקוח מהמשתמש
        /// </summary>
        /// <returns></returns>
        private static Customer AskCustomer(int code = 0)
        {
            int id;
            string name;
            string address;
            string phone;
            Console.WriteLine("Enter id of the customer");
             int.TryParse(Console.ReadLine(), out id);
            Console.WriteLine("Enter name of the customer");
            name = Console.ReadLine();
            Console.WriteLine("Enter address of the customer");
            address = Console.ReadLine();
            Console.WriteLine("Enter phone of the customer");
            phone = Console.ReadLine();
            return new Customer(id, name, address, phone);
        }

    }
}
