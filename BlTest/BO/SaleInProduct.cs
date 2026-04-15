using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class SaleInProduct
    {
        public int idSaleInProduct { get; set; }
        public int amountSaleInProduct { get; set; }
        public double priceSaleInProduct { get; set; }
        public bool isSaleInProductSpecialToAll { get; set; }
        public SaleInProduct(int saleId, int count_Sale, double price_Sale, bool if_All_Customers)
        {
            idSaleInProduct = saleId;
            amountSaleInProduct = count_Sale;
            priceSaleInProduct = price_Sale;
            isSaleInProductSpecialToAll = if_All_Customers;

        }
        public SaleInProduct()
        {

        }
    }
}
