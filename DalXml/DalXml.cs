using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;

namespace Dal
{
    internal sealed class DalXml : IDal
    {
       
        private static  DalXml _instance = new DalXml();
        public static DalXml Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DalList();
                }
                return _instance;
            }
        }
        private DalXml()
        {

        }
        public ICustomer Customer => new CustomerImplementation();

        public ISale Sale => new SaleImplementation();

        public IProduct Product => new ProductImplementation();

    }
}
