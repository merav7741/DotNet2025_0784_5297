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
                Console.WriteLine("שלום ןברכה");
                Initialization.Initialize(s_dal);

               
                //SubMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        //private static void SubMenu<T>(ICrud<T> crud, string title, Add add, Update update) { }

        private static void ProductMenu() { }

        //private static Sale AskSale(int code = 0) { }

        //private static Client AskClient(int identity = 0) { }

        private static void AddProduct() { }

        private static void AddSale() { }

        private static void AddClient() { }

        private static void UpdateProduct() { }

        private static void UpdateSale() { }

        private static void UpdateClient() { }

        private static void ReadAll<T>(List<T> list) { }

        //private static void ReadAll<T>(ICrud<T> icrud) { }

        private static void Read<T>(ICrud<T> crud)
        {
            try
            {
                Console.WriteLine("Enter Code");
                int code = int.Parse(Console.ReadLine());
                Console.WriteLine(crud.Read(code));

            }
            catch (Exception e) { Console.WriteLine(e.Message); }


        }

        private static void Delete<T>(ICrud<T> crud) { }

        //public static int PrintMainMenu() { }

        //public static int PrintSubMenu(string item) { }

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
