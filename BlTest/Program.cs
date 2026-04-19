using BlApi;

namespace BlTest
{
    internal class Program
    {
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get;
        static void Main()
        {
            DalTest.Initialization.Initialize();

            int choice;

            do
            {
                Console.WriteLine("1 - Customer");
                Console.WriteLine("2 - Product");
                Console.WriteLine("3 - Sale");
                Console.WriteLine("0 - Exit");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    case 1:
                        CustomerMenu();
                        break;
                    case 2:
                        // ProductMenu();
                        break;
                    case 3:
                        // SaleMenu();
                        break;
                    deafult:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }

            } while (choice != 0);
        }

        static void CustomerMenu()
        {
            Console.WriteLine("1 - Read");
            Console.WriteLine("2 -Create");
            Console.WriteLine("3  -delete");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    try
                    {
                        var customer = s_bl.Customer.Read(1);
                        Console.WriteLine(customer);
                    }
                    catch (BO.BlDoesNotExistException ex)
                    {
                        Console.WriteLine("Customer not found");
                    }
                    catch (BO.BlGeneralException ex)
                    {
                        Console.WriteLine("General error");
                    }
                    break;
                case 2:
                    try
                    {

                    }
            }
        }

        static void ProductMenu()
        {

        }

    }
}
