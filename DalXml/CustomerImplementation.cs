using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DalApi;
using DO;

namespace Dal
{
    internal class CustomerImplementation : ICustomer
    {
        const string CUSTOMERS_FILE_PATH = "../xml/customers.xml";
        public int Create(Customer c)
        {
            List<Customer> customersList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            using (StreamReader sr = new StreamReader(CUSTOMERS_FILE_PATH))
                customersList = serializer.Deserialize(sr) as List<Customer>;
            if (!customersList.Exists(cus => cus.Id == c.Id))
            {
                customersList.Add(c);
                using (StreamWriter sw = new StreamWriter(CUSTOMERS_FILE_PATH))
                    serializer.Serialize(sw, customersList);
                return c.Id;
            }
            else
                throw new DalExsistException($"Customer with id: {c.Id} already exists");
        }

        public void Delete(int id)
        {
            List<Customer> customersList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            using (StreamReader sr = new StreamReader(CUSTOMERS_FILE_PATH))
                customersList = serializer.Deserialize(sr) as List<Customer>;
            if (customersList.Exists(cus => cus != null && cus.Id == id))
            {
                customersList.Remove(customersList.Find(cus => cus!.Id == id));
                using (StreamWriter sw = new StreamWriter(CUSTOMERS_FILE_PATH))
                    serializer.Serialize(sw, customersList);
            }
            else
                throw new DalNotExistException($"Customer with id: {id} was not found");
        }

        public Customer? Read(int id)
        {
            List<Customer> customersList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            using (StreamReader sr = new StreamReader(CUSTOMERS_FILE_PATH))
                customersList = serializer.Deserialize(sr) as List<Customer>;
            if (customersList.Exists(cus => cus != null && cus.Id == id))
                return customersList.Find(cus => cus!.Id == id);
            else
                throw new DalNotExistException($"Customer with id: {id} was not found");
        }

        public Customer? Read(Func<Customer, bool> filter)
        {
            List<Customer> customersList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            using (StreamReader sr = new StreamReader(CUSTOMERS_FILE_PATH))
                customersList = serializer.Deserialize(sr) as List<Customer>;
            return customersList.FirstOrDefault(filter!);
        }

        public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
        {
            List<Customer> customersList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            using (StreamReader sr = new StreamReader(CUSTOMERS_FILE_PATH))
                customersList = serializer.Deserialize(sr) as List<Customer>;
            if (filter != null)
                return customersList!.Where<Customer>(filter).ToList()!;
            return new List<Customer?>(customersList != null ? customersList : new List<Customer?>())!;
        }

        public void Update(Customer c)
        {
            List<Customer> customersList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            using (StreamReader sr = new StreamReader(CUSTOMERS_FILE_PATH))
                customersList = serializer.Deserialize(sr) as List<Customer>;
            if (customersList.Exists(cus => cus != null && cus.Id == c.Id))
            {
                customersList.Remove(customersList.Find(cus => cus.Id == c.Id));
                customersList.Add(c);
                using (StreamWriter sw = new StreamWriter(CUSTOMERS_FILE_PATH))
                    serializer.Serialize(sw, customersList);
            }
            else
                throw new DalNotExistException($"Customer with id: {c.Id} was not found");
        }
    }
}
