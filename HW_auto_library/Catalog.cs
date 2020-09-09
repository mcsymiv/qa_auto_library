using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HW_auto_library
{
    public class Catalog
    {
        public List<Book> bookList = new List<Book>() {
            new Book(1, "Hobbit", "Tolkien", 0, 1, new Dictionary<string, int>()),
            new Book(2, "Harry Potter and the Half Blood Prince", "Rowling", 0, 1, new Dictionary<string, int>()),
            new Book(3, "The Key Ideas", "Sigmund Freud", 0, 1, new Dictionary<string, int>()),
            new Book(4, "I am Robot", "Isaac Asimov", 0, 1, new Dictionary<string, int>()),
            new Book(5, "Foundation", "Isaac Asimov", 0, 1, new Dictionary<string, int>())
        };

        public void AddNewBook(int bookID, string title, string author, bool available, int days, int aomunt, Dictionary<string, int> readers)
        {
            bookList.Add(new Book(bookID, title, author, days, 1, readers));
        }
        public void RemoveBook(int bookID)
        {
            if (bookList.Count != 0 || bookID == bookList[bookID].bookID)
            {
                bookList.RemoveAll(book => book.bookID == bookID);
            }
        }
        public void AddDaysToBook(int bookID, int days)
        {
            foreach (var book in bookList)
            {
                if (book.bookID == bookID)
                {
                    book.numberOfDays += days;
                }
            }
        }
        public void WriteReader(string lastName, int bookIDtaken, int days)
        {
            foreach (var book in bookList)
            {
                if (book.bookID == bookIDtaken)
                {
                    book.readers.Add(lastName, days);
                }
            }
        }
        public string ShowAuthors()
        {
            int option = 0;
            List<string> authors = new List<string>();
            int authorsCount = 1;
            foreach (var book in bookList)
            {
                if (!authors.Contains(book.author))
                {
                    authors.Add(book.author);
                }
            }
            foreach (var author in authors)
            {
                Console.WriteLine("{0} | {1}", authorsCount, author);
                authorsCount++;
            }
            while (true)
            {
                Console.WriteLine("Select author to show books");
                if (int.TryParse(Console.ReadLine(), out option) && option > 0 && option < authorsCount + 1)
                {
                    Console.Clear();
                    break;
                }
            }
            return authors[option - 1];

        }
        public void ShowAuthorsBooks(string authorsName)
        {
            Console.WriteLine($"{authorsName}'s books:");
            foreach (var book in bookList)
            {
                if (book.author == authorsName)
                {
                    Console.WriteLine($"Title: {book.title}");
                }
            }
        }

        public void SortBy(int sortOption)
        {
            if (sortOption == 1)
            {
                bookList = bookList.OrderBy(book => book.author).ToList();
                foreach (var book in bookList)
                {
                    Console.WriteLine("____________________________________");
                    Console.WriteLine("Author: {0} | Title: {1} | Days: {2}", book.author, book.title, book.numberOfDays);
                }
            }
            else
            {
                bookList = bookList.OrderBy(book => book.title).ToList();
                foreach (var book in bookList)
                {
                    Console.WriteLine("____________________________________");
                    Console.WriteLine("Title: {0} | Author: {1} | Days: {2}", book.title, book.author, book.numberOfDays);
                }
            }
        }
        public void ShowWhoReadsWhat()
        {
            foreach (var book in bookList)
            {
                Console.WriteLine("____________________________________");
                Console.WriteLine("Author: {0} | Title: {1} | Days: {2}", book.author, book.title, book.numberOfDays);
                Console.WriteLine("List of readers:");
                foreach (var reader in book.readers)
                {
                    Console.WriteLine("{0} | {1} days", reader.Key, reader.Value);
                }
            }
        }
        public int ChooseBook(string readRemove)
        {
            int bookID = 1;
            int bookAvailable = 1;
            foreach (var book in bookList)
            {
                if (bookList.Contains(book))
                {
                    Console.WriteLine("____________________________________");
                    Console.WriteLine("BookID: {0} || Author: {1} | Title: {2}", book.bookID, book.author, book.title);
                    bookAvailable++;
                }
            }
            do
            {
                Console.WriteLine("\t ***** \t");
                Console.WriteLine($"To {readRemove} a book select it's BookID number:\t");
            } while (!int.TryParse(Console.ReadLine(), out bookID) || bookID <= 0 || bookID > bookAvailable - 1);

            foreach (var book in bookList)
            {
                if (book.bookID == bookID)
                {
                    bookID = book.bookID;
                }
            }

            return bookID;
        }
        public void Search()
        {
            string input;
            Dictionary<string, string> results = new Dictionary<string, string>();
            Console.Clear();
            Console.Write("Type book title or key word:\t");
            input = Console.ReadLine().ToLower();
            foreach (var book in bookList)
            {
                string title = book.title.ToLower();
                if (title.Contains(input))
                {
                    results.Add(book.author, book.title);
                }
            }
            Console.WriteLine("Search result:");
            Console.WriteLine("__________________________");
            if (results.Count == 0)
            {
                Console.WriteLine("Sorry, we couldn't find any {0}", input);
            }
            else
            {
                foreach (var result in results)
                {
                    Console.WriteLine("{0} by {1}", result.Value, result.Key);
                }
            }

        }
    }
}
