using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductInOrder
    {
        public int idProductInOrder { get; set; }
        public string nameProductInOrder { get; set; }
        public double basePriceProductInOrder { get; set; }
        public int amountProductInOrder { get; set; }
        public List<SaleInProduct> listSaleToProductInOrder { get; set; } = new();

        public double finalPriceProductInOrder { get; set; }
        public ProductInOrder()
        {
            listSaleToProductInOrder = new List<SaleInProduct>();
        }
    }
}
