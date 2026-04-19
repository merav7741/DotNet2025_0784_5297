using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlImplementation;

namespace BlApi
{
    public class Factory
    {

        public static IBl Get()
        {
            IBl bI = new Bl();
            return bI;
        }
    }
}
