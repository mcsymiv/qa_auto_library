using System;
using System.Collections.Generic;
using System.Text;

namespace HW_auto_library
{
    public class Customer
    {
        public string lastName;
        public Dictionary<int, int> hasBooks = new Dictionary<int, int>();
        
        public Customer(string lastName, Dictionary<int,int> hasBooks)
        {
            this.lastName = lastName;
            this.hasBooks = hasBooks;
        }
    }
}
