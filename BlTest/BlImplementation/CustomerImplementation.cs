using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class CustomerImplementation: BlApi.ICustomer
    {
        //private DalApi.IDal _dal = DalApi.Factory.Get();
        private readonly DalApi.IDal _dal = DalApi.Factory.Get();


    }
}
