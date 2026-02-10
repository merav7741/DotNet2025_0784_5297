using DO;
using DalApi;


namespace Dal
{
    public class CustomerImplementation : ICustomer
    {
        /// <summary>
        /// פונקציה להוספת לקוח 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Create(Customer item)
        {
            foreach (Customer? customer in DataSource.customers)
            {
                if (customer != null && customer!.Id == item.Id)
                {
                    throw new DalIdExsistException("This customer with this id already exists");
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
            bool found = false;
            foreach (Customer? customer in DataSource.customers)
            {
                if (customer != null && customer.Id == id)
                {
                    DataSource.customers.Remove(customer);
                    found = true;
                }
            }

            if (!found)
                throw new DalIdNotExistException("This customer not exists in the customers list");
        }
        /// <summary>
        /// פונקציה שמחזירה לקוח על פי id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer? Read(int id)
        {
            foreach (Customer? customer in DataSource.customers)
            {
                if (customer?.Id == id)
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
            return DataSource.customers == null ? null : new List<Customer>(DataSource.customers);
        }
        /// <summary>
        /// פונקציה לעדכון פרטי לקוח 
        /// </summary>
        /// <param name="item"></param>
        public void Update(Customer item)
        {
            if (DataSource.customers.Any(c => c?.Id == item.Id))
            {
                Delete(item.Id);
            }
            DataSource.customers.Add(item);
        }
    }
}

