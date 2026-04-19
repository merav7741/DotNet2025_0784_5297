using BO;

namespace BlTest;

internal class Program
{
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

    static void Main()
    {
        Console.WriteLine("BlTest is ready");
    }
}
