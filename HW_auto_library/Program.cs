using System;
using System.Collections.Generic;
using System.Net;

namespace HW_auto_library
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu();
            Console.WriteLine("Welcome, to the Library!");
            while (true)
            {
                int requestNum = menu.GeneralQueryNumber();
                menu.ShowOptions(requestNum);
                if (requestNum == 8)
                {
                    Console.Clear();
                    Console.WriteLine("Goodbye");
                    break;
                }
            }

        }
    }
}
