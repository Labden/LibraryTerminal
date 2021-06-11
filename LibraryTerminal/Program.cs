using System;
using System.Collections.Generic;

namespace LibraryTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            bool goOn = true;
            while (goOn == true)
            {
                //Library object holds list of books
                Library library = new Library();

                //main menu
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome to Grand Circus Library \n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("0) Display book list");
                Console.WriteLine("1) Search by Title or Author");
                //options will be implimented later
                Console.WriteLine("2) Suggest a book -- does not work, will impliment later");
                Console.WriteLine("3) Book of the Day -- does not work, will impliment later");
                Console.WriteLine("4) Burn down the Libray...? ");
                Console.WriteLine("5) Exit");
                Console.WriteLine();
                int input = GetuserInput("Please select and option");

                if (input == 0)
                {
                    
                }
                else if (input == 1)
                {
                    //search for title of Author
                }
                else if (input == 2)
                {
                    //suggest a book
                }
                else if (input == 3)
                {
                    //book of the day
                    //get book at random
                }
                else if (input == 4)
                {
                    //burndown library
                }
                else if (input == 5)
                {
                    goOn = GetContinue();
                }
                else
                {
                    GetuserInput("Please select and option");
                }
            }

        }

    

        public static void PrintWholeList(List<Books> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {items[i].Title}, -- {items[i].Author}" );
            }
        }

        public static int GetuserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            int index = int.Parse(input);

            if(index >= 0 && index <= 12)
            {
                return index;
            }
            else
            {
                return GetuserInput("Please select and option provided");
            }

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
