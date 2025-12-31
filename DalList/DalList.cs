using DalApi;

namespace Dal
{
    internal class DalList :IDal
    {
        public IProduct product => new ProductImplementation();
        public ISale sale => new SaleImplementation();
        public ICustomer customer => new CustomerImplementation();

    }
}
