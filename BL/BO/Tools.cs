using System.Collections;
using System.Reflection;
using System.Text;

namespace BO;

internal static class Tools
{
    public static string ToStringProperty<T>(this T t)
    {
        if (t == null)
            return "null";

        Type type = t.GetType();
        var sb = new StringBuilder();

        if (type.IsPrimitive || type.IsEnum || t is string || t is DateTime || t is decimal || t is double || t is int || t is bool)
            return t.ToString() ?? string.Empty;

        if (t is IEnumerable list && t is not string)
        {
            sb.AppendLine("[");
            foreach (var item in list)
            {
                sb.AppendLine(item == null ? "null" : item.ToStringProperty());
            }
            sb.AppendLine("]");
            return sb.ToString();
        }

        sb.AppendLine($"{type.Name} {{");
        foreach (PropertyInfo prop in type.GetProperties())
        {
            var value = prop.GetValue(t, null);
            sb.AppendLine($"  {prop.Name}: {value.ToStringProperty()}");
        }
        sb.AppendLine("}");
        return sb.ToString();
    }

    public static Customer ConvertDoCustomerToBo(this DO.Customer customer) =>
        new(customer.Id, customer.Name, customer.Address, customer.Phone);

    public static DO.Customer ConvertBoCustomerToDo(this Customer customer) =>
        new(customer.Id, customer.Name, customer.Address, customer.Phone);

    public static Product ConvertDoProductToBo(this DO.Product product) =>
        new(product.Id, product.Name, (Categories)product.Category, product.Price, product.CountStock);

    public static DO.Product ConvertBoProductToDo(this Product product) =>
        new(product.Id, product.Name, (DO.Categories)product.Category, product.Price, product.CountStock);

    public static Sale ConvertDoSaleToBo(this DO.Sale sale) =>
        new(sale.Id, sale.ProductId, sale.QuantityForSale, sale.SalePrice, sale.IsSaleToAllCustomer, sale.StartSale, sale.EndSale);

    public static DO.Sale ConvertBoSaleToDo(this Sale sale) =>
        new(sale.Id, sale.ProductId, sale.QuantityForSale, sale.SalePrice, sale.IsSaleToAllCustomer, sale.StartSale, sale.EndSale);

    public static SaleInProduct ConvertDoSaleToSaleInProduct(this DO.Sale sale) =>
        new()
        {
            idSaleInProduct = sale.Id,
            amountSaleInProduct = sale.QuantityForSale ?? 0,
            priceSaleInProduct = sale.SalePrice,
            isSaleInProductSpecialToAll = sale.IsSaleToAllCustomer
        };

    public static ProductInOrder ConvertDoProductToProductInOrder(this DO.Product product, int amount = 0) =>
        new()
        {
            idProductInOrder = product.Id,
            nameProductInOrder = product.Name,
            basePriceProductInOrder = product.Price,
            amountProductInOrder = amount,
            listSaleToProductInOrder = new List<SaleInProduct>(),
            finalPriceProductInOrder = 0
        };
}
