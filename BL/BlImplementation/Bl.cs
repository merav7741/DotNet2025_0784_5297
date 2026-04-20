using BlApi;
using BO;
namespace BlImplementation;

internal class Bl : IBl
{
    public IProduct iProduct => new ProductImplementation();
    public ICustomer iCustomer => new CustomerImplementation();
    public ISale iSale => new SaleImplementation();
    public IOrder iOrder => new OrderImplementation();
}
