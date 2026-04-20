using BlApi;
using BO;
namespace BlImplementation;

internal class Bl : IBl
{
    public IProduct Product => new ProductImplementation();
    public ICustomer Customer => new CustomerImplementation();
    public ISale Sale => new SaleImplementation();
    public IOrder Order => new OrderImplementation();
}
