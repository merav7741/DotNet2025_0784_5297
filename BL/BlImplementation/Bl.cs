using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;

namespace BlImplementation
{
    namespace BlImplementation
    {
        internal class Bl : IBl
        {

            //public IProduct iProduct => new ProductImplementation();

            //public ICustomer iCustomer => new CustomerImplementation();

            //public ISale iSale => new SaleImplementation();

            //public IOrder iOrder => new OrderImplementation();
            public IProduct iProduct => throw new NotImplementedException();

            public ICustomer iCustomer => throw new NotImplementedException();

            public ISale iSale => throw new NotImplementedException();

            public IOrder iOrder => throw new NotImplementedException();
        }
    }

}

