using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Order
    {
            public bool isPreferedCustomer { get; set; }
            public List<ProductInOrder> listProductInOrder { get; set; }

            public double finalPrice { get; set; }
            public Order()
            {
                listProductInOrder = new List<ProductInOrder>();

            }
    }
}
