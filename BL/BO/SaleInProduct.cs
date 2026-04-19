namespace BO;

public class SaleInProduct
{
    public int idSaleInProduct { get; set; }
    public int amountSaleInProduct { get; set; }
    public double priceSaleInProduct { get; set; }
    public bool isSaleInProductSpecialToAll { get; set; }

    public SaleInProduct() { }

    public SaleInProduct(int saleId, int countSale, double priceSale, bool ifAllCustomers)
    {
        idSaleInProduct = saleId;
        amountSaleInProduct = countSale;
        priceSaleInProduct = priceSale;
        isSaleInProductSpecialToAll = ifAllCustomers;
    }

    public override string ToString() => this.ToStringProperty();
}
