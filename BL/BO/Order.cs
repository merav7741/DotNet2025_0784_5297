namespace BO;

public class Order
{
    public bool isPreferedCustomer { get; set; }
    public List<ProductInOrder> listProductInOrder { get; set; } = new();
    public double finalPrice { get; set; }

    public Order() { }

    public override string ToString() => this.ToStringProperty();
}
