using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DalApi;

namespace BlApi
{
    public interface IBl
    {
        IProduct iProduct { get; }
        ICustomer iCustomer { get; }
        ISale iSale { get; }
        IOrder iOrder { get; }
    }
}
