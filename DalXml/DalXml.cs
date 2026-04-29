using DalApi;

namespace Dal;

internal sealed class DalXml : IDal
{
    private static readonly DalXml instance = new();
    public static DalXml Instance => instance;

    private DalXml() { }

    public ICustomer Customer => new CustomerImplementation();
    public IProduct Product => new ProductImplementation();
    public ISale Sale => new SaleImplementation();
}