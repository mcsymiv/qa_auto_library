using System;
using System.Collections.Generic;
using System.Text;

namespace HW_auto_library
{
    public class Journal
    {
        public List<Customer> customers = new List<Customer>();
        public void AddNewCustomer(string lastName, Dictionary<int,int> hasBooks)
        {
            customers.Add(new Customer(lastName, hasBooks));
        }

    }
}
