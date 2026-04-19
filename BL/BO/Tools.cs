using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Reflection;
using DO;


namespace BO
{
    internal static class Tools
    {
        public static string ToStringProperty<T>(this T t)
        {
            if (t == null)
                return "null";

            Type type = t.GetType();
            var sb = new StringBuilder();

            if (type.IsPrimitive || type.IsEnum || t is string || t is DateTime || t is decimal)
                return t.ToString();

            if (t is System.Collections.IEnumerable list && !(t is string))
            {
                sb.AppendLine("[");
                foreach (var item in list)
                {
                    sb.AppendLine(item.ToStringProperty());
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

        public static BO.Customer ConvertDoCustomerToBo(this DO.Customer customer)
        {
            return new BO.Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone
            };
        }

        public static DO.Customer ConvertBoCustomerToDo(this BO.Customer customer)
        {
            return new DO.Customer(
                customer.Id,
                customer.Name,
                customer.Address,
                customer.Phone
            );
        }

        public static DO.Product ConvertBoProductToDo(this BO.Product product)
        {
            return new DO.Product(
                product.Id,
                product.Name,
                (DO.Categories)product.Category,
                product.Price,
                product.CountStock
            );
        }

        public static BO.Product ConvertDoProductToBo(this DO.Product product)
        {
            return new BO.Product(
                product.Id,
                product.Name,
                (BO.Categories)product.Category,
                product.Price,
                product.CountStock
            );
        }

        public static BO.Sale ConvertDoSaleToBo(this DO.Sale sale)
        {
            return new BO.Sale
            {
                Id = sale.Id,
                ProductId = sale.ProductId,
                QuantityForSale = sale.QuantityForSale,
                SalePrice = sale.SalePrice,
                IsSaleToAllCustomer = sale.IsSaleToAllCustomer,
                StartSale = sale.StartSale,
                EndSale = sale.EndSale
            };
        }

        public static DO.Sale ConvertBoSaleToDo(this BO.Sale sale)
        {
            return new DO.Sale(
                sale.Id,
                sale.ProductId,
                sale.QuantityForSale,
                sale.SalePrice,
                sale.IsSaleToAllCustomer,
                sale.StartSale,
                sale.EndSale
            );
        }

        public static BO.SaleInProduct ConvertDoSaleToSaleInProduct(this DO.Sale sale)
        {
            return new BO.SaleInProduct
            {
                idSaleInProduct = sale.Id,
                amountSaleInProduct = sale.QuantityForSale ?? 0,
                priceSaleInProduct = sale.SalePrice,
                isSaleInProductSpecialToAll = sale.IsSaleToAllCustomer
            };
        }
        public static BO.ProductInOrder ConvertDoProductToProductInOrder(this DO.Product product, int amount = 0)
        {
            return new BO.ProductInOrder
            {
                idProductInOrder = product.Id,
                nameProductInOrder = product.Name,
                basePriceProductInOrder = product.Price,
                amountProductInOrder = amount,
                listSaleToProductInOrder = new List<BO.SaleInProduct>(),
                finalPriceProductInOrder = 0
            };

        }
    }
}
