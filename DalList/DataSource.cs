using DO;

namespace Dal
{
    internal static class DataSource
    {
        /// <summary>
        /// רשימות שמכילות הפניות לישות מאותו הטיפוס
        /// </summary>
        internal static List<Customer?> customers = new List<Customer?>();
        internal static List<Sale?> sales = new List<Sale?>();
        internal static List<Product?> products = new List<Product?>();

        internal static class Config
        {
            internal const int ProductId = 1000;
            private static int _productId = ProductId;
            public static int NextProduct
            {
                get { return _productId++; }
            }

            private const int InitialSaleId = 1000; 
            private static int _nextSaleId = InitialSaleId;

            public static int NextSaleId
            {
                get { return _nextSaleId++; } 
            }

        }
    }
}
