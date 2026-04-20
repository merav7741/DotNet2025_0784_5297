namespace BlApi;

public interface IBl
{
    IProduct iProduct { get; }
    ICustomer iCustomer { get; }
    ISale iSale { get; }
    IOrder iOrder { get; }
}
