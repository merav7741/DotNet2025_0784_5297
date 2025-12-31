using DalApi;


namespace Dal
{
    public class DalList :IDal
    {
        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();
        public ICustomer Customer => new CustomerImplementation();

    }
}
