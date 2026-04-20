using DalApi;

namespace Dal;

internal sealed class DalXml : IDal
{
    private static readonly DalXml _instance = new();
    public static DalXml Instance => _instance;
    private DalXml() { }

    public ICustomer Customer => new CustomerImplementation();
    public ISale Sale => new SaleImplementation();
    public IProduct Product => new ProductImplementation();
}
