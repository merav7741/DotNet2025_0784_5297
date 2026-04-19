using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string Phone { get; set; }

        public Customer()
        {
            
        }
        public Customer(int id, string name, string? address, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}
