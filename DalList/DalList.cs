using DalApi;


namespace Dal
{
    internal sealed class DalList : IDal
    {
        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();
        public ICustomer Customer => new CustomerImplementation();

        private DalList()
        {

        }

        private static DalList _instance = new DalList();
        public DalList Instance
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

       
    }
}
