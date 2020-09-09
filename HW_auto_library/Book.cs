using System;
using System.Collections.Generic;
using System.Text;

namespace HW_auto_library
{
    public class Book
    {
        public int bookID;
        public string title;
        public string author;
        public int numberOfDays;
        public int amount;
        public Dictionary<string, int> readers;
        
        public Book(int bookID, string title, string author, int numberOfDays, int amount, Dictionary<string,int> readers)
        {
            this.bookID = bookID;
            this.title = title;
            this.author = author;
            this.numberOfDays = numberOfDays;
            this.amount = amount;
            this.readers = readers;
        }
    }
}
