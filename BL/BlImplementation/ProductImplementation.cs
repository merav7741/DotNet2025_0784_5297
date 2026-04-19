using BlApi;
using BO;
namespace BlImplementation;

internal class ProductImplementation : IProduct
{
    private readonly DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Product item) => _dal.Product.Create(item.ConvertBoProductToDo());

    public BO.Product? Read(int id)
    {
        var product = _dal.Product.Read(id);
        return product?.ConvertDoProductToBo();
    }

    public BO.Product? Read(Func<BO.Product, bool>? filter)
    {
        if (filter == null) return null;
        return _dal.Product.ReadAll().Select(p => p.ConvertDoProductToBo()).FirstOrDefault(filter);
    }

    public List<BO.Product> ReadAll(Func<BO.Product, bool>? filter = null)
    {
        var products = _dal.Product.ReadAll().Select(p => p.ConvertDoProductToBo());
        return filter == null ? products.ToList() : products.Where(filter).ToList();
    }

    public void Update(BO.Product item) => _dal.Product.Update(item.ConvertBoProductToDo());

    public void Delete(int id) => _dal.Product.Delete(id);

    public void AllSalesInDate(BO.ProductInOrder productInOrder, bool isPreferedCus)
    {
        var sales = _dal.Sale
            .ReadAll()
            .Where(s => s.ProductId == productInOrder.idProductInOrder)
            .Where(s => (!s.StartSale.HasValue || s.StartSale.Value <= DateTime.Now) && (!s.EndSale.HasValue || s.EndSale.Value >= DateTime.Now))
            .Where(s => !s.QuantityForSale.HasValue || s.QuantityForSale.Value <= productInOrder.amountProductInOrder)
            .Where(s => isPreferedCus || s.IsSaleToAllCustomer)
            .Select(s => s.ConvertDoSaleToSaleInProduct())
            .OrderBy(s => s.amountSaleInProduct == 0 ? double.MaxValue : s.priceSaleInProduct / s.amountSaleInProduct)
            .ToList();

        productInOrder.listSaleToProductInOrder = sales;
    }
}
