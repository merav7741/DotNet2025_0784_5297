namespace BO;

public class ProductInOrder
{
    public int idProductInOrder { get; set; }
    public string nameProductInOrder { get; set; } = string.Empty;
    public double basePriceProductInOrder { get; set; }
    public int amountProductInOrder { get; set; }
    public List<SaleInProduct> listSaleToProductInOrder { get; set; } = new();
    public double finalPriceProductInOrder { get; set; }

    public ProductInOrder() { }

    public override string ToString() => this.ToStringProperty();
}
