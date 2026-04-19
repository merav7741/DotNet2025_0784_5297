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
        private readonly DalApi.IProduct _product;
        private readonly BlApi.ICustomer _customer;
        private readonly BlApi.ISale _sale;
        private readonly IOrder _order;

        public Bl(DalApi.IProduct product, BlApi.ICustomer customer, BlApi.ISale sale, IOrder order)
        {
            _product = product;
            _customer = customer;
            _sale = sale;
            _order = order;
        }

        public IProduct iProduct => (IProduct)_product; 
        public ICustomer iCustomer => _customer;
        public ISale iSale => _sale;
        public IOrder iOrder => _order;
    }
}
