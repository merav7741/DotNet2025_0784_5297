using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;

namespace Dal
{
    internal sealed class DalXml : IDal
    {
        //readonly ?? 
        private static readonly DalXml instance = new DalXml();
        public static DalXml Instance => instance;
        private DalXml()
        {

        }
        public ICustomer Customer => new CustomerImplementation();

        public ISale Sale => new SaleImplementation();

        public IProduct Product => new ProductImplementation();

    }
}
