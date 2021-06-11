using System;
using System.Collections.Generic;

namespace LibraryTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Library library = new Library();

            //Books b1 = new Books("title", "author", true, null);
            //b1.CheckOut();
            //b1.CheckOut();

            //library.SearchbyTitleOrAuthor(library.BookList, "Jack Kerouac");




           
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
                string input = GetuserInput("Please select and option : ");

                if (input == "0")
                {
                    PrintWholeList(library.BookList);

                }
                else if (input == "1")
                {

                    Console.WriteLine("Author or Title?");
                    string authortitle = Console.ReadLine().ToLower();

                    if (authortitle == "author")
                    {
                        Console.WriteLine("Search by Author");
                        string keyword = Console.ReadLine();
                        library.SearchbyAuthor(keyword);
                    }
                    else if (authortitle == "title")
                    {
                        //search by Author
                        Console.WriteLine("Search by Title");
                        string keyword = Console.ReadLine();
                        library.SearchbyTitle(keyword);
                    }
                    else
                    { Console.WriteLine("Invalid Input"); }

                }
                else if (input == "2")
                {
                    //suggest a book
                }
                else if (input == "3")
                {
                    //book of the day
                    //get book at random
                }
                else if (input == "4")
                {
                    //burndown library
                }
                else if (input == "5")
                {
                    goOn = GetContinue();
                }
                else
                {
                    GetuserInput("Please select and option");
                }
            }

        }

        public static void TitleOrAuthor()
        {

            Console.WriteLine("Searching by Title or Author?");
            string userAnswer = Console.ReadLine().ToLower().Trim();
            if (userAnswer == "title")
            {
                //search by title
            }
            else if (userAnswer == "author")
            {
                //search by author
                //library.SearchbyTitleOrAuthor("input");
            }
            else
            {
                Console.WriteLine("Please enter a valid input");
            }

        }

        public static void PrintWholeList(List<Books> items)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--Displaying Book List-- \n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {items[i].Title}, --- {items[i].Author}" );
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
