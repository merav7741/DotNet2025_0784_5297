using DO;
using DalApi;


namespace Dal
{
    internal class CustomerImplementation : ICustomer
    {
        /// <summary>
        /// פונקציה להוספת לקוח 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Create(Customer item)
        {
            for (int i = 0; i < DataSource.customers.Count; i++)
            {
                if (DataSource.customers[i] != null && DataSource.customers[i].Id == item.Id)
                {
                    throw new InvalidOperationException("לקוח זה כבר קיים ברשימת הלקוחות");
                }
            }

            DataSource.customers.Add(item);
            return item.Id;
        }
        /// <summary>
        /// /פונקציה למחיקת לקוח
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            //var customerToDelete = DataSource.customers.FirstOrDefault(Customer => Customer.Id == id);

            //if (customerToDelete == null)
            //{
            //    throw new InvalidOperationException($"!!!מוצר זה לא נמצא");
            //}
            //DataSource.customers.Remove(customerToDelete);

            bool found = false;
            for (int i = 0; i < DataSource.customers.Count; i++)
            {
                if (DataSource.customers[i] != null && DataSource.customers[i].Id == id)
                {
                    DataSource.customers.Remove(DataSource.customers[i]);
                    found = true;
                }
            }

            if (!found)

                throw new InvalidOperationException("הלקוח לא נמצא למחיקה");
        }
        /// <summary>
        /// פונקציה שמחזירה לקוח על פי id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer? Read(int id)
        {
            foreach (Customer customer in DataSource.customers)
            {
                if (customer.Id == id)
                    return customer;
            }
            return null;
        }
        /// <summary>
        /// פונקציה שמחזירה את מערך הלקוחות
        /// </summary>
        /// <returns></returns>
        public List<Customer> ReadAll()
        {
            return DataSource.customers == null ? null : DataSource.customers;
        }
        /// <summary>
        /// פונקציה לעדכון פרטי לקוח 
        /// </summary>
        /// <param name="item"></param>
        public void Update(Customer item)
        {
            bool f = false;
            foreach (Customer customer in DataSource.customers)
            {
                if (customer.Id == item.Id)
                {
                    f = true;
                    DataSource.customers.Remove(customer);
                }
            }
            if (f)
            {
                DataSource.customers.Add(item);
                return;
            }
            throw new Exception("לא נמצע מוצר זהה לעדכון");

        }
    }
}

