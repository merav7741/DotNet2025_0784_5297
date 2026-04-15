using DalApi;


namespace Dal
{
    internal sealed class DalList : IDal
    {
        
        private static readonly DalList instance = new DalList();
        public static DalList Instance { get { return instance; } }

        private DalList()
        {

        }

        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();
        public ICustomer Customer => new CustomerImplementation();

      


    }
}
