using BlApi;
using BO;
namespace BlImplementation;

internal class OrderImplementation : IOrder
{
    private readonly DalApi.IDal _dal = DalApi.Factory.Get;

    public void SearchSaleForProduct(BO.ProductInOrder productInOrder, bool isFavorite)
    {
        var sales = _dal.Sale
            .ReadAll()
            .Where(s => s.ProductId == productInOrder.idProductInOrder)
            .Where(s => (!s.StartSale.HasValue || s.StartSale.Value <= DateTime.Now) && (!s.EndSale.HasValue || s.EndSale.Value >= DateTime.Now))
            .Where(s => !s.QuantityForSale.HasValue || s.QuantityForSale.Value <= productInOrder.amountProductInOrder)
            .Where(s => isFavorite || s.IsSaleToAllCustomer)
            .Select(s => s.ConvertDoSaleToSaleInProduct())
            .OrderBy(s => s.amountSaleInProduct == 0 ? double.MaxValue : s.priceSaleInProduct / s.amountSaleInProduct)
            .ToList();
        productInOrder.listSaleToProductInOrder = sales;
    }

    public void CalcTotalPriceForProduct(BO.ProductInOrder productInOrder)
    {
        int count = productInOrder.amountProductInOrder;
        double total = 0;
        List<BO.SaleInProduct> usedSales = new();
        foreach (var sale in productInOrder.listSaleToProductInOrder)
        {
            if (sale.amountSaleInProduct <= 0 || count < sale.amountSaleInProduct)
                continue;

            int numOfSales = count / sale.amountSaleInProduct;
            total += numOfSales * sale.priceSaleInProduct;
            count %= sale.amountSaleInProduct;
            usedSales.Add(sale);
            if (count == 0) break;
        }
        total += count * productInOrder.basePriceProductInOrder;
        productInOrder.finalPriceProductInOrder = total;
        productInOrder.listSaleToProductInOrder = usedSales;
    }

    public void CalcTotalPrice(BO.Order order)
    {
        order.finalPrice = order.listProductInOrder.Sum(p => p.finalPriceProductInOrder);
    }

    public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int countOrder)
    {
        if (countOrder <= 0)
            throw new BO.BLThereIsNotEnoughInStock("Amount must be greater than zero");

        var doProduct = _dal.Product.Read(productId) ?? throw new BO.BLIdNotFoundException("Product not found");
        var productInOrder = order.listProductInOrder.FirstOrDefault(p => p.idProductInOrder == productId);

        if (productInOrder != null)
        {
            if (doProduct.CountStock < productInOrder.amountProductInOrder + countOrder)
                throw new BO.BLThereIsNotEnoughInStock("Not enough in stock");
            productInOrder.amountProductInOrder += countOrder;
        }
        else
        {
            if (doProduct.CountStock < countOrder)
                throw new BO.BLThereIsNotEnoughInStock("Not enough in stock");
            productInOrder = doProduct.ConvertDoProductToProductInOrder(countOrder);
            order.listProductInOrder.Add(productInOrder);
        }
        SearchSaleForProduct(productInOrder, order.isPreferedCustomer);
        CalcTotalPriceForProduct(productInOrder);
        CalcTotalPrice(order);
        return productInOrder.listSaleToProductInOrder;
    }

    public void DoOrder(BO.Order order)
    {
        foreach (var product in order.listProductInOrder)
        {
            var doProduct = _dal.Product.Read(product.idProductInOrder) ?? throw new BO.BLIdNotFoundException("Product not found");
            if (doProduct.CountStock < product.amountProductInOrder)
                throw new BO.BLThereIsNotEnoughInStock("Not enough in stock");

            var updatedProduct = doProduct with { CountStock = doProduct.CountStock - product.amountProductInOrder };
            _dal.Product.Update(updatedProduct);
        }
    }
}
