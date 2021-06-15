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
            //open and read the txt file
            StreamReader reader = new StreamReader(filePath);

            //read file to the end 
            string output = reader.ReadToEnd();
            //split at the end of eveny line and store that line in string array
            string[] lines = output.Split('\n');

            //create a new list to store book objects
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
                //LibraryIO creates an instance of an object to reference and hold whole book list
                LIbraryIO libraryIO = new LIbraryIO(BookList);

                //main menu
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome to Grand Circus Library");
                Console.WriteLine("--Main Menu--\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1) Display book list"); // show whole book list with up to date information
                Console.WriteLine("2) Search by Title");  //search list by title / key word
                Console.WriteLine("3) Search by Author"); //search list by author / key word
                Console.WriteLine("4) Add Book to the Library"); // ask user to add a new book to the list
                Console.WriteLine("5) Return Book"); // will call return book funtion
                Console.WriteLine("6) Book of the Day"); //get random book from list and ask user to check it out
                Console.WriteLine("7) Burn down the Library...? "); //Pull a Julius Caesar
                Console.WriteLine("8) Exit"); //close program
                Console.WriteLine();
                int input = GetuserInput(BookList, "Please select an option");

                if (input == 1)
                {
                    bool menuOption = true;
                    while (menuOption == true)
                    {
                        //display book list txt file
                        libraryIO.PrintWholeList();
                        Console.Write("Would you like to check out a book from this list? (y/n): ");
                        string userAnswer = Console.ReadLine().ToLower().Trim();
                        if (userAnswer == "y" || userAnswer == "yes")
                        {
                            Console.WriteLine("Please select a book using its index");
                            try
                            {
                                int bookselected = int.Parse(Console.ReadLine());
                                libraryIO.CheckOut(bookselected,BookList);
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
                        Console.WriteLine("These books match your search results:");

                        List<Books> searchresultstitle = new List<Books>();

                        searchresultstitle=libraryIO.SearchbyTitle(keyword);

                        Console.WriteLine("Would you like to check out any books from this list? (y/n)");
                        string userAnswer = Console.ReadLine().ToLower().Trim();
                        if (userAnswer == "y" || userAnswer == "yes")
                        {
                            Console.WriteLine("Please select the index of the book you would like to check out:");
                            try
                            {
                                int index = int.Parse(Console.ReadLine());

                                libraryIO.CheckOut(index, searchresultstitle,BookList);
                                Console.WriteLine("Thank you, enjoy your book");
                                menuOption = false;
                                Console.ReadLine();
                                Console.Clear();

                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Please select a vaild index");
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

                        List<Books> searchresults = new List<Books>();
                        
                        searchresults=(libraryIO.SearchbyAuthor(keyword));

                        Console.WriteLine("Would you like to check out any books from this list? (y/n)");
                        string userAnswer = Console.ReadLine().ToLower().Trim();
                        if (userAnswer == "y" || userAnswer == "yes")
                        {
                            Console.WriteLine("Please select the index of the book you would like to check out:");
                            try
                            {
                                int index = int.Parse(Console.ReadLine());

                                libraryIO.CheckOut(index, searchresults,BookList);
                                Console.WriteLine("Thank you, enjoy your book");
                                menuOption = false;
                                Console.ReadLine();
                                Console.Clear();

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please select a vaild index");
                            }
                            catch (ArgumentOutOfRangeException)
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
                    bool goOn6 = true;
                    while (goOn6==true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("--Book of the day!--");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("The book of the day is: \n");
                        List<Books> bookOfTheDay = BookOfTheDay(BookList);
                        for (int i = 0; i < bookOfTheDay.Count; i++)
                        {
                            Console.WriteLine($"{bookOfTheDay[i].Title} by {bookOfTheDay[i].Author}");
                        }

                        Console.WriteLine("Would you like to check out this book? (y/n)");

                        string randresponse = Console.ReadLine().ToLower();

                        if (randresponse == "y" || randresponse == "yes")
                        {
                            libraryIO.CheckOut(1,bookOfTheDay,BookList);
                            goOn6 = false;
                        }
                        else if(randresponse == "n" || randresponse == "no")
                        {
                            Console.WriteLine("Moving back to main menu");
                            goOn6 = false;
                        }



                        Console.ReadLine();
                        Console.Clear();
                    }
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
        public static List<Books> BookOfTheDay(List<Books> Book)
        {
            Random random = new Random();
           
            int randomBook = random.Next(1, Book.Count + 1);

            List<Books> randlist = new List<Books>();

            for (int i = 1; i < Book.Count; i++)
            {
                if (randomBook == i)
                {
                    randlist.Add(Book[i]);
                    return randlist;
                }
            }
            return null;
        }
    }
}

