using DO;
using DalApi;
using System.Reflection;
using Tools;
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
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start create new customer");
            foreach (Customer? customer in DataSource.customers)
            {
                if (customer != null && customer!.Id == item.Id)
                {
                    LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "Eror cant create new customer because  id already exists");
                    throw new DalExsistException("This customer with this id already exists");
                }
            }
            DataSource.customers.Add(item);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end create new customer successfull");
            return item.Id;

        }
        /// <summary>
        /// /פונקציה למחיקת לקוח
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start delete customer");
            var customerToDelete = DataSource.customers.FirstOrDefault(customer => customer.Id == id);
            if (customerToDelete == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "Eror cant delete the customer because  id not exists");
                throw new DalNotExistException("The product not exists in customers list");
            }
            DataSource.customers.Remove(customerToDelete);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end delete customer succesfull");
        }
        /// <summary>
        /// פונקציה שמחזירה לקוח על פי id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start read with id custome");
            var customerRead = DataSource.customers.FirstOrDefault(Customer => Customer.Id == id);
            if (customerRead == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "Eror cant read  Customer because  not found customer with this filter");
                throw new DalNotExistException("The Customer not exists in customers list");
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end read with id Customer succesfull");
            return customerRead;

        }
        /// <summary>
        /// פוקציה קריאה לפי תנאי מסוים
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="DalNotExistException"></exception>
        public Customer? Read(Func<Customer, bool> filter)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start read with filter custome");
            var customerRead = DataSource.customers.FirstOrDefault(C => filter(C!));
            if (customerRead == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "Eror cant read  customer because  not found customer with this filter");
                throw new DalNotExistException("Not Found customer with this filter in customers list");
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end read with filter Customer succesfull");
            return customerRead;
        }
        /// <summary>
        /// פונקציה שמחזירה את מערך הלקוחות
        /// </summary>
        /// <returns></returns>
        public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "start read all customer");
            if (filter == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end read all customer return full customers list becausu the filter is null");
                return new List<Customer?>(DataSource.customers);
            }
            var customer = DataSource.customers.Where(c => filter(c!));
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end read all customer succesfull");
            return customer.ToList();
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

