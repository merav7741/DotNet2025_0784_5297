using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// ישות מבצע בחנות
    /// </summary>
    public class Sale
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? QuantityForSale { get; set; }
        public double SalePrice { get; set; }
        public bool IsSaleToAllCustomer { get; set; }
        public DateTime? StartSale { get; set; }
        public DateTime? EndSale { get; set; }

        public Sale()
        {
            
        }
        public Sale(int id, int? productId, int? quantityForSale, double salePrice, bool isSaleToAllCustomer, DateTime? startSale, DateTime? endSale)
        {
            Id = id;
            ProductId = productId;
            QuantityForSale = quantityForSale;
            SalePrice = salePrice;
            IsSaleToAllCustomer = isSaleToAllCustomer;
            StartSale = startSale;
            EndSale = endSale;
        }
    }
}
