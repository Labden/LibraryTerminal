using System;
using System.Collections.Generic;

namespace LibraryTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            bool displayMenu = true;
            while (displayMenu == true)
            {
                //Library object holds list of books
                Library library = new Library();

                //main menu -- Header
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome to Grand Circus Library \n");
                Console.ForegroundColor = ConsoleColor.White;

                //user options
                Console.WriteLine("1) Display book list");
                Console.WriteLine("2) Search by Title or Author");
                Console.WriteLine("3) Suggest a book -- does not work, will impliment later");
                Console.WriteLine("4) Book of the Day -- does not work, will impliment later");
                Console.WriteLine("5) Burn down the Libray...? ");
                Console.WriteLine("6) Exit");
                Console.WriteLine();
                string input = GetuserInput("Please select an option : ");

                //call method based on user input
                if (input == "1")
                {
                    Console.Clear();
                    PrintWholeList(library.BookList);
                    //add methof here
                    //ask if they want to check out a book from the list

                }
                else if (input == "2")
                {
                    Console.Clear();
                    TitleOrAuthor(library);
                   

                }
                else if (input == "3")
                {
                    //suggest a book
                    //write to input/output file and display the list of suggested books
                }
                else if (input == "4")
                {
                    //book of the day
                    //get book at random from list and ask user to check it out
                }
                else if (input == "5")
                {
                    //burndown library
                    BurnLibrary();
                    Console.Clear();
                }
                else if (input == "6")
                {
                    displayMenu = GetContinue();
                }
                else
                {
                    GetuserInput("Please select and option");
                }
            }
        }
        public static void TitleOrAuthor(Library library)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--Searching by Author or Title--");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Would you like to search by author or title: ");

            string authortitle = Console.ReadLine().ToLower();
            if (authortitle == "author")
            {
                //search by author
                Console.WriteLine("Searching by Author");
                string keyword = Console.ReadLine();
                library.SearchbyAuthor(keyword);

                //add method here
                //need to ask if they want to check this book out
            }
            else if (authortitle == "title")
            {
                //search by title
                Console.WriteLine("Searching by Title");
                string keyword = Console.ReadLine();
                library.SearchbyTitle(keyword);

                //add method here
                //need to ask if they want to check this book out
            }
            else
            { 
                Console.WriteLine("Invalid Input");
                TitleOrAuthor(library);
            }

        }

        public static void PrintWholeList(List<Books> items)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--Displaying Book List-- \n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1} {items[i].Title}, by: {items[i].Author}" );
            }
        }

        public static string GetuserInput(string message)
        {
            Console.Write(message + " ");
            string input = Console.ReadLine().ToLower().Trim();
            try 
            {
                int index = int.Parse(input);
                if(index >= 0 && index <= 12)
                {
                    return index.ToString();
                }
            }
            catch (FormatException)
            {
                return GetuserInput("Please select a valid option");
            }

            if (input == "y" || input == "yes")
            {
                return input;
            }
            else if (input == "n" || input == "no")
            {
                return input;
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
                Console.Clear();
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

        public static void BurnLibrary()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--Burn down library--");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Are you sure? (y/n)");
            string input = Console.ReadLine().ToLower().Trim(); ;
            if(input == "y" || input == "yes")
            {
                for(int i = 0; i <= 100; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("BURNING BOOKS");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("BURNING BOOKS");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("BURNING BOOKS");
                }
                Console.WriteLine("Burning Complete...");
                Console.ReadLine();
                Console.Clear();
            }
            else if(input == "n" || input == "no")
            {
                Console.WriteLine("Right, Arson is a crime.");
                Console.WriteLine("Probably not a good idea to burn down the library...");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                BurnLibrary();
            }
        }
    }
}
