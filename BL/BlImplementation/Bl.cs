using BlApi;
using BO;
namespace BlImplementation;

internal class Bl : IBl
{
    private readonly ICustomer _customer;
    private readonly IProduct _product;
    private readonly ISale _sale;
    private readonly IOrder _order;

    internal Bl()
    {
        _customer = new CustomerImplementation();
        _product = new ProductImplementation();
        _sale = new SaleImplementation();
        _order = new OrderImplementation();
    }

    public ICustomer Customer => _customer;
    public IProduct Product => _product;
    public ISale Sale => _sale;
    public IOrder Order => _order;
}