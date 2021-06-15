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
            //load BooksList.txt file 
            string filePath = @"..\..\..\BooksList.txt";
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
                Console.WriteLine("Welcome to Grand Circus Library");
                Console.WriteLine("--Main Menu--\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1) Display book list"); // complete
                Console.WriteLine("2) Search by Title");
                Console.WriteLine("3) Search by Author");
                Console.WriteLine("4) Add Book to the Library"); //exceptions need to be added and tested  
                Console.WriteLine("5) Return Book"); // will call return book funtion
                Console.WriteLine("6) Book of the Day"); //does not work, functionality to be added later
                Console.WriteLine("7) Burn down the Library...? "); //functionality to be added in later
                Console.WriteLine("8) Exit");
                Console.WriteLine();
                int input = GetuserInput(BookList, "Please select an option");

                if (input == 1)
                {
                    bool menuOption = true;
                    while (menuOption == true)
                    {
                        //display book list txt file
                        libraryIO.PrintWholeList();
                        Console.Write("Would you like to check out a book from this this? (y/n): ");
                        string userAnswer = Console.ReadLine().ToLower().Trim();
                        if (userAnswer == "y" || userAnswer == "yes")
                        {
                            Console.WriteLine("Please select a book using its index");
                            try
                            {
                                int bookselected = int.Parse(Console.ReadLine());
                                libraryIO.CheckOut(bookselected);
                                Console.WriteLine("Thank you, enjoy your book");
                                menuOption = false;
                                Console.ReadLine();
                                Console.Clear();
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("I didn't understand what book you wanted to check out");
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("That index is out of range");
                            }
                        }
                        else if (userAnswer == "n" || userAnswer == "no")
                        {
                            Console.WriteLine("Moving back to main menu");
                            Console.ReadLine();
                            Console.Clear();
                            menuOption = false;
                        }
                    }

                }
                //search list by title/key words
                else if (input == 2)
                {
                    bool menuOption = true;
                    while (menuOption == true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("--Search by Title--");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Please enter a key word you want to search for:");

                        string keyword = Console.ReadLine().ToLower().Trim();
                        libraryIO.SearchbyTitle(keyword);

                        Console.WriteLine("Would you like to check out any books from this list? (y/n)");
                        string userAnswer = Console.ReadLine().ToLower().Trim();
                        if (userAnswer == "y" || userAnswer == "yes")
                        {
                            Console.WriteLine("Please select the index of the book you would like to check out:");
                            try
                            {
                                int index = int.Parse(Console.ReadLine());

                                libraryIO.CheckOut(index);
                                Console.WriteLine("Thank you, enjoy your book");
                                menuOption = false;
                                Console.ReadLine();
                                Console.Clear();

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please select a vaild index");
                            }
                        }
                        else if(userAnswer == "n" || userAnswer == "no")
                        {
                            Console.WriteLine("Moving back to main menu");
                            Console.ReadLine();
                            Console.Clear();
                            menuOption = false;
                        } 
                    }
                }
                //search list by author/key words
                else if (input == 3)
                {
                    bool menuOption = true;
                    while (menuOption == true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("--Search by Author--");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Please enter a key word you want to search for:");

                        string keyword = Console.ReadLine().ToLower().Trim();
                        libraryIO.SearchbyTitle(keyword);

                        Console.WriteLine("Would you like to check out any books from this list? (y/n)");
                        string userAnswer = Console.ReadLine().ToLower().Trim();
                        if (userAnswer == "y" || userAnswer == "yes")
                        {
                            Console.WriteLine("Please select the index of the book you would like to check out:");
                            try
                            {
                                int index = int.Parse(Console.ReadLine());

                                libraryIO.CheckOut(index);
                                Console.WriteLine("Thank you, enjoy your book");
                                menuOption = false;
                                Console.ReadLine();
                                Console.Clear();

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please select a vaild index");
                            }
                        }
                        else if (userAnswer == "n" || userAnswer == "no")
                        {
                            Console.WriteLine("Moving back to main menu");
                            Console.ReadLine();
                            Console.Clear();
                            menuOption = false;
                        }
                    }
                }
                //Add new book from user to book list
                else if (input == 4)
                {
                    //add book to list and txt file
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("--Add a book to the list--");
                    Console.ForegroundColor = ConsoleColor.White;
                    libraryIO.AddBook();

                    Console.WriteLine("Adding new book complete");
                    Console.ReadLine();
                    Console.Clear();
                    
                }
                else if (input == 5)
                {
                    //call reutnr book funtion here
                    //add data validation?

                    bool optionOne = true;
                    while (optionOne == true)
                    {
                        //display book list txt file
                        libraryIO.PrintWholeList();
                        Console.Write("Would you like to return a book from this list? (y/n): ");
                        string userAnswer = Console.ReadLine().ToLower().Trim();
                        if (userAnswer == "y" || userAnswer == "yes")
                        {
                            Console.WriteLine("Please select a book using its index");
                            try
                            {
                                int bookselected = int.Parse(Console.ReadLine());
                                libraryIO.ReturnBook(bookselected);
                                Console.WriteLine("Thank you for returning the book");
                                optionOne = false;
                                Console.ReadLine();
                                Console.Clear();
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("I didn't understand what book you wanted to check out");
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("That index is out of range");
                            }
                        }
                        else if (userAnswer == "n" || userAnswer == "no")
                        {
                            Console.WriteLine("Moving back to main menu");
                            Console.ReadLine();
                            Console.Clear();
                            optionOne = false;
                        }
                    }
                }
                //call bookoftheday to get a random book
                else if (input == 6)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("--Book of the day!--");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("The book of the day is: \n");
                    Books bookOfTheDay = BookOfTheDay(BookList);
                    Console.WriteLine($"{bookOfTheDay.Title} by {bookOfTheDay.Author}");
                    Console.ReadLine();
                    Console.Clear();

                    //ADD -- ask user if they want to check this book out

                }
                //call burndown library
                else if (input == 7)
                {
                    BurnLibrary();
                }

                else if (input == 8)
                {

                    goOn = GetContinue();
                }
                else
                {
                    GetuserInput(BookList, "Please select an option");
                }

            }
        }


        public static int GetuserInput(List<Books> BookLists, string message)
        {
            Console.Write(message + " ");
            string input = Console.ReadLine().ToLower().Trim();
            try
            {
                int index = int.Parse(input);

                if (index >= 1 && index <= BookLists.Count)

                {
                    return index;
                }
            }
            catch (FormatException)
            {

                return GetuserInput(BookLists, "Please select a valid option");
            }
            return GetuserInput(BookLists, "Please select a valid index");


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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--Burn down library--");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Woah, Are you sure? (y/n)");
            string input = Console.ReadLine().ToLower().Trim(); ;
            if (input == "y" || input == "yes")
            {
                for (int i = 0; i <= 100; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("BURNING BOOKS");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("BURNING BOOKS");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("BURNING BOOKS");
                }
                Console.WriteLine("Burning Complete...");
                Console.ReadLine().ToLower().Trim();
                Console.Clear();
            }
            else if (input == "n" || input == "no")
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
        public static Books BookOfTheDay(List<Books> Book)
        {
            Random random = new Random();

            int randomBook = random.Next(1, Book.Count + 1);
            for (int i = 1; i < Book.Count; i++)
            {
                if (randomBook == i)
                {
                    return Book[i];
                }
            }
            return null;
        }
    }
}

