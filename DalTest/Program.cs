using DalApi;
using DO;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Xml.Linq;
namespace DalTest
{
    internal class Program
    {
        static readonly IDal s_dal = new Dal.DalList();

        private static void Main(string[] args)
        {
            try
            {

                Initialization.Initialize(s_dal);


                //SubMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void Read<T>(ICrud<T> crud)
        {
            int choice;
            try
            {
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
            catch (Exception e)
            { Console.WriteLine(e.Message); }


        }

        public static int PrintMainMenu()
        {
            int choice;
            Console.WriteLine("Main Menu: 1 - Product 2 - Sales 3 - Customers 0 - Exit");
            int.TryParse(Console.ReadLine(), out choice);
            return choice;
        }

        public static int PrintSubMenu(string item)
        {
            int choice;
            Console.WriteLine($"{item} Menu: 1 - Add 2 - Update 3 - Read 4- Read All 5 - Delete 0 - Back");
            int.TryParse(Console.ReadLine(), out choice);
            return choice;
        }
        public static void ProductMenu()
        {
            int choice;
            do
            {
                choice = PrintMainMenu();
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
                        break ;
                        case 4:
                        ReadAll(s_dal.Product!);
                        break ;
                        case 5:
                         Delete(s_dal.Product);
                        break ;


                }
              
            } while (choice != 0);

        } 
        public static void CustomerMenu()
        {

        }
        public static void SaleMenu()
        {
            int choice;
            do
            {
                choice = PrintMainMenu();
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
        private static void Delete<T>(ICrud<T> crud) { }

        private static void AddProduct()
        {

        }
        private static void AddSale()
        {

        }
        private static void UpdateProduct() { }
        private static void UpdateSale()
        {

        }
        private static void ReadAll<T>(ICrud<T> icrud)
        {
            foreach (T item in icrud.ReadAll())
                if (item != null)
                    Console.WriteLine(item);
        }
        

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
                category = (Categories)cat;
            Console.WriteLine("Enter Price");
            if (!double.TryParse(Console.ReadLine(), out price)) price = 10;
            Console.WriteLine("Enter count in stock");
            if (!int.TryParse(Console.ReadLine(), out count)) count = 0;

            return new Product(code, name, category, price, count);
        }

    }
}
