using System;
using System.Collections.Generic;

namespace LibraryTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            /*
            foreach (Books b in library.BookList) 
            {
                Console.WriteLine(b.Status);
            }
            */

            PrintWholeList(library.BookList);

            bool goOn = true;
            while (goOn == true)
            {



            }
            goOn = GetContinue();

        }

        public static void PrintWholeList(List<Books> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {items[i].Title}, -- {items[i].Author}" );
            }
        }

        public static int GetuserInput(string inputType)
        {
            int input;
            Console.WriteLine(inputType);
            input = int.Parse(Console.ReadLine());
            return input;
        }

        static bool GetContinue()
        {
            Console.WriteLine("Would you like to check out another book? (y/n)");
            string answer = Console.ReadLine().ToUpper();

            if (answer == "Y" || answer == "YES")
            {
                return true;
            }
            else if (answer == "N" || answer == "NO")
            {
                Console.WriteLine("Goodbye!");
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand that, please try again");
                return GetContinue();

            }
        }
        public static bool IsValidIndex(List<Books> booklist, int index)
        {
            if (index >= 0 && index < booklist.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
