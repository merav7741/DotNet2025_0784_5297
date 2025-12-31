using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DO
{
    /// <summary>
    /// ישות מבצע בחנות 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="ProductId"></param>
    /// <param name="QuantityForSale"></param>
    /// <param name="SalePrice"></param>
    /// <param name="IsSaleToAllCustomer"></param>
    /// <param name="StartSale"></param>
    /// <param name="EndSale"></param>
    public record Sale
        (
          int Id,
          int? ProductId,
          int? QuantityForSale,
          double SalePrice,
          bool IsSaleToAllCustomer,
          DateTime? StartSale,
          DateTime? EndSale

        )

    {
        public Sale() : this(0, 0, null, 0, true, null, null)
        {

        }
    }
}
