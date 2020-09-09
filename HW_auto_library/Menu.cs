using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HW_auto_library
{
    public class Menu
    {
        public Catalog catalog = new Catalog();
        public Journal journal = new Journal();

        public int GeneralQueryNumber()
        {
            Console.WriteLine("---------------------------------------");
            int queryNum;
            while (true)
            {
                Console.WriteLine("1. Show books list.");
                Console.WriteLine("2. Show books list of specific author.");
                Console.WriteLine("3. Take book to read.");
                Console.WriteLine("4. Add book to the library.");
                Console.WriteLine("5. Remove book from library.");
                Console.WriteLine("6. Show who reads book.");
                Console.WriteLine("7. Search.");
                Console.WriteLine("8. Exit Library.");
                if (int.TryParse(Console.ReadLine(), out queryNum) || queryNum < 0 || queryNum > 8)
                {
                    Console.Clear();
                    break;
                }
            }
            return queryNum;
        }
        public void ShowOptions(int queryNum)
        {
            int option,
                days,
                booksTotal;
            string authorsName,
                   lastName,
                   title,
                   author;
            switch (queryNum)
            {
                case 1:
                    option = SortOption();
                    catalog.SortBy(option);
                    break;
                case 2:
                    authorsName = catalog.ShowAuthors();
                    catalog.ShowAuthorsBooks(authorsName);
                    break;
                case 3:
                    option = catalog.ChooseBook("read");
                    days = AskDaysToRead(option);
                    lastName = LettersNumbersInputOnly("last name");
                    catalog.AddDaysToBook(option, days);
                    catalog.WriteReader(lastName, option, days);
                    Console.WriteLine($"{lastName} you must return this book in {days} {(days == 1 ? "day" : "days")}");
                    break;
                case 4:
                    booksTotal = catalog.bookList.Count;
                    title = LettersNumbersInputOnly("TITLE of the book");
                    author = LettersNumbersInputOnly("AUTHOR of the book");
                    foreach (var book in catalog.bookList)
                    {
                        if (book.author == author || book.title == title)
                        {
                            book.amount++;
                        }
                    }
                    catalog.AddNewBook(booksTotal + 1, title, author, true, 0, 1, null);
                    Console.WriteLine("**** Book has been added ****");
                    break;
                case 5:
                    option = catalog.ChooseBook("remove");
                    if (catalog.bookList.Count == 0)
                    {
                        Console.WriteLine("Sorry, the library is already empty");
                        break;
                    }
                    else
                    {
                        catalog.RemoveBook(option);
                        Console.WriteLine("**** Book has been removed ****");
                    }
                    break;
                case 6:
                    catalog.ShowWhoReadsWhat();
                    break;
                case 7:
                    catalog.Search();
                    break;
            }
        }
        public string LettersNumbersInputOnly(string input)
        {
            string name;
            do
            {
                Console.Write($"Please, enter {input}:\t");
                name = Console.ReadLine();
            } while (!Regex.IsMatch(name, @"[0-9a-zA-Z]"));
            return name;
        }
        public int SortOption()
        {
            int option = 0;
            while (true)
            {
                Console.WriteLine("1. Show catalog in aplphabetical order. | by Author");
                Console.WriteLine("2. Show catalog in aplphabetical order. | by Title");
                if (int.TryParse(Console.ReadLine(), out option) && option > 0 || option < 3)
                {
                    Console.Clear();
                    break;
                }
            }
            return option;
        }
        public int AskDaysToRead(int bookID)
        {
            int days = 0;
            foreach (var book in catalog.bookList)
            {
                if (book.bookID == bookID)
                {
                    Console.WriteLine($"You are about to take {book.title} by {book.author}");
                }
            }
            while (true)
            {
                Console.WriteLine($"For how many days, do you want to take it?");
                Console.Write($"We offer a limit up until 150 days:\t");
                if (int.TryParse(Console.ReadLine(), out days) && (days > 0 && days < 150))
                {
                    Console.Clear();
                    break;
                }
            }
            return days;
        }
    }
}
