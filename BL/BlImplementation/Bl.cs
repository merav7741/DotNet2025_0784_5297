using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;

namespace BlImplementation
{
    internal class Bl : IBl
    {
        public DalApi.IProduct iProduct => throw new NotImplementedException();
        public BlApi.ICustomer iCustomer => throw new NotImplementedException();
        public BlApi.ISale iSale => throw new NotImplementedException();
        public IOrder iOrder => throw new NotImplementedException();

      
    }
}
