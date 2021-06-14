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
            string filePath = @"BooksList.txt";
            StreamReader reader = new StreamReader(filePath);

            string output = reader.ReadToEnd();

            string[] lines = output.Split('\n');

            List<Books> BookList = new List<Books>();

            reader.Close();

            //Convert each line into a Books object
            foreach (string line in lines)
            {
                Books b = LIbraryIO.ConvertToBooks(line);
                if (b != null)
                {
                    BookList.Add(b);
                }
            }



            bool goOn = true;
                while (goOn == true)
                {
                    //Library object pulls
                    LIbraryIO libraryIO = new LIbraryIO(BookList);

                    //main menu
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Welcome to Grand Circus Library \n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) Display book list");
                    Console.WriteLine("2) Search by Title"); //These function seperately, but it would be cool to add a third option to search all terms 
                                                                       //options will be implimented later
                     Console.WriteLine("3) Search by Author");
                    Console.WriteLine("4) Suggest a book -- does not work, will impliment later");
                    Console.WriteLine("5) Book of the Day -- does not work, will impliment later");
                    Console.WriteLine("6) Burn down the Library...? "); //functionality to be added in later
                    Console.WriteLine("7) Add Book to the Library"); //exceptions need to be added and tested
                    Console.WriteLine("8) Checkout Book from Library"); //excpetions need to be added and tested
                    Console.WriteLine("9) Exit");
                    Console.WriteLine();
                    int input = GetuserInput("Please select and option");

                if (input == 1)
                {
                    libraryIO.PrintWholeList();
                }
                else if (input == 2)
                {
                        Console.WriteLine("Search by Author");
                        string keyword = Console.ReadLine();
                        libraryIO.SearchbyAuthor(keyword);
                }
                else if (input == 3)
                {
                        Console.WriteLine("Search by Title");
                        string keyword = Console.ReadLine();
                        libraryIO.SearchbyTitle(keyword);
                }
                else if (input == 4)
                {
                        //suggest a book
                }
                else if (input == 5)
                {
                        //book of the day
                        //get book at random
                    }
                    else if (input == 6)
                    {
                        //burndown library
                    }
                    else if (input == 7)
                    {
                        libraryIO.AddBook();
                    }
                    else if (input == 8)
                    {
                        Console.WriteLine("Select a book by index number");
                        int bookselected = int.Parse(Console.ReadLine());
                    libraryIO.CheckOut(libraryIO.BookList[bookselected-1]);
                    }
                    else if (input == 9)
                    {
                        goOn = GetContinue();
                    }
                    else
                    {
                        GetuserInput("Please select an option");
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

        //public static Books ConvertToBooks(string line)
        //{
        //    string[] properties = line.Split(',');


        //    if (properties.Length == 4)
        //    {
        //        bool bstatus = bool.Parse(properties[2]);
        //        Books b = new Books(properties[0], properties[1], bstatus, properties[3]);
        //        return b;
        //    }
        //    else
        //    {
        //        return null;
        //    }


        //}

        //public string BooksToString(Books b)
        //{
        //    string output = $"{b.Title}, {b.Author}, {b.Status},{b.DueDate} \n";
        //    return output;
        //}
    }
}
