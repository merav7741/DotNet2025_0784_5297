namespace BO;

public class Order
{
    public bool isPreferedCustomer { get; set; }
    public List<ProductInOrder> listProductInOrder { get; set; }

    public double finalPrice { get; set; }
    public Order()
    {
        listProductInOrder = new List<ProductInOrder>();

    }
}
