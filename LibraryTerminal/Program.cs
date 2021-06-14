using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace LibraryTerminal
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePath = @"..\..\..\BooksList.txt";
            StreamReader reader = new StreamReader(filePath);

            string output = reader.ReadToEnd();

            string[] lines = output.Split('\n');

            List<Books> bookList = new List<Books>();

            reader.Close();

            //Convert each line into a Books object
            foreach (string line in lines)
            {
                Books b = LIbraryIO.ConvertToBooks(line);
                if (b != null)
                {
                    bookList.Add(b);
                }
            }



            bool goOn = true;

            while (goOn == true)
            {
                //Library object pulls
                LIbraryIO libraryIO = new LIbraryIO(bookList);

                //main menu
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome to Grand Circus Library \n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1) Display book list");
                Console.WriteLine("2) Search by Title"); //These function seperately, but it would be cool to add a third option to search all terms 
                Console.WriteLine("3) Search by Author");
                Console.WriteLine("4) Add Book to the Library"); //exceptions need to be added and tested  
                Console.WriteLine("5) Book of the Day -- does not work, will impliment later");
                Console.WriteLine("6) Burn down the Library...? "); //functionality to be added in later
                Console.WriteLine("7) Exit");
                Console.WriteLine();
                int input = GetuserInput("Please select and option");

                if (input == 1)
                {
                    //display book list txt file
                    libraryIO.PrintWholeList();
                    //ask user to check out a book from the list
                    //call checkout?

                    libraryIO.CheckOut();



                }

                else if (input == 2)

                {
                    //ADD DATA VALIDATION!!
                    //search list by title
                    Console.WriteLine("Search by Title");
                    string keyword = Console.ReadLine().ToLower().Trim();
                    libraryIO.SearchbyTitle(keyword);

                    //ask if they want to check out the book they have searched for
                }
                else if (input == 3)
                {
                    //ADD DATA VALIDATION!!
                    //search list by author
                    Console.WriteLine("Search by Author");
                    string keyword = Console.ReadLine().ToLower().Trim();
                    libraryIO.SearchbyAuthor(keyword);

                    //ask if they want to check out the book they have searched for
                }
                else if (input == 4)
                {
                    //add book to list and txt file
                    libraryIO.AddBook();
                }

                else if (input == 5)

                {

                    //book of the day
                    //get book at random
                }
                else if (input == 6)
                {
                    //burndown library
                    BurnLibrary();
                    Console.Clear();

                }

                else if (input == 7)
                {
                    //ADD DATA VALIDATION!!
                    //Exit program
                    goOn = GetContinue();
                }
                else
                {
                    GetuserInput("Please select an option");
                }

            }
        }
            
        
        public static void TitleOrAuthor(LIbraryIO library)
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

        public static int GetuserInput(string message)
        {
            Console.Write(message + " ");
            string input = Console.ReadLine().ToLower().Trim();
            try 
            {
                int index = int.Parse(input);
                if(index >= 0 && index <= 12)
                {
                    return index;
                }
            }
            catch (FormatException)
            {
                return GetuserInput("Please select a valid option");
            }
            return GetuserInput("Please select a valid index");

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

