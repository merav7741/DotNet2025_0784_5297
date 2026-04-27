using BlApi;
using BO;
namespace BlImplementation;

internal class Bl : IBl
{
    // הגדרת משתנים פרטיים שיחזיקו את המימושים
    private readonly ICustomer _customer;
    private readonly IProduct _product;
    private readonly ISale _sale;
    private readonly IOrder _order;

    // יצירת המופעים פעם אחת בלבד בתוך הבנאי
    internal Bl()
    {
        _customer = new CustomerImplementation();
        _product = new ProductImplementation();
        _sale = new SaleImplementation();
        _order = new OrderImplementation();
    }

    // חשיפת המשתנים דרך ה-Properties של הממשק
    public ICustomer Customer => _customer;
    public IProduct Product => _product;
    public ISale Sale => _sale;
    public IOrder Order => _order;
}