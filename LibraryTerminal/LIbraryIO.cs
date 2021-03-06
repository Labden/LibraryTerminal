using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace LibraryTerminal
{
    public class LIbraryIO
    {

        public List<Books> BookList { get; set; }

        public LIbraryIO(List<Books> BookList)
        {
            this.BookList = BookList;
        }

        public List<Books> SearchbyAuthor(string keyword)
        {
            var byAuthor = BookList.Where(Book => Book.Author.ToLower().Contains(keyword.ToLower())).ToList(); ;

            for(int i = 0; i < byAuthor.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {byAuthor[i].Title} by {byAuthor[i].Author}");
            }
            return byAuthor;
        }

        public List<Books> SearchbyTitle(string keyword)
        {
            var byTitle = BookList.Where(Book => Book.Title.ToLower().Contains(keyword.ToLower())).ToList();
            for(int i = 0; i < byTitle.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {byTitle[i].Title} by {byTitle[i].Author}");
            }
            return byTitle;
        }

        //Add a book to the txt file and list of books
        public void AddBook()
        {
            string filePath = @"..\..\..\BooksList.txt";

            //no exception testing
            Console.WriteLine("Please input the book's Title");
            string booktitle = Console.ReadLine();

            Console.WriteLine("Please input the book's Author");
            string bookauthor = Console.ReadLine();

            Books b = new Books(booktitle, bookauthor, true, null);

            this.BookList.Add(b);

            string line = BooksToString(b);
            Console.WriteLine(line);

            StreamReader reader = new StreamReader(filePath);
            string original = reader.ReadToEnd();
            reader.Close();


            StreamWriter writer = new StreamWriter(filePath);
            //Write override everything with the string
            writer.Write(original + line);

            writer.Close();
        }

        //convert book object to string
        public static string BooksToString(Books b)
        {
            string output = $"{b.Title}, {b.Author}, {b.Status},{b.DueDate} \n";
            return output;
        }

        //This takes a string from our file and makes it into an object 
        public static Books ConvertToBooks(string line)
        {
            string[] properties = line.Split(',');


            if (properties.Length == 4)
            {
                bool bstatus = bool.Parse(properties[2]);
                Books b = new Books(properties[0], properties[1], bstatus, properties[3]);
                return b;
            }
            else
            {
                return null;
            }


        }

        //prints out a list of books from the text file by index
        public void PrintWholeList()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--Displaying Book List--");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for (int i = 0; i < BookList.Count; i++)
            {

                if (BookList[i].Status == true)
                {
                    Console.WriteLine($"{i + 1}: {BookList[i].Title}, by {BookList[i].Author}, On Shelf");

                }
                else
                { Console.WriteLine($"{i + 1}: {BookList[i].Title}, by {BookList[i].Author} due back by {BookList[i].DueDate}"); }

            }
            Console.WriteLine();
        }

        //uses current day and sets that date to the book property DueDate and sets a return by time
        public void CheckOut(int index, List<Books> BookList)
        {
            Books chosenbook = BookList[index - 1];

            if (chosenbook.Status == true)
            {
                //sets the dueDate 14 days ahead from the current system time
                DateTime dueDate = DateTime.Now.AddDays(14);
                chosenbook.DueDate = chosenbook.DateToString(dueDate);
                Console.WriteLine($"You have checked out {chosenbook.Title}, by {chosenbook.Author} Please bring it back by {dueDate}");
                chosenbook.Status = false;

                //takes updated b and turns it to a string.
                string newline = LIbraryIO.BooksToString(chosenbook);

                //Repulls the whole list from the text file into program

                string filePath = @"..\..\..\BooksList.txt";
                StreamReader reader = new StreamReader(filePath);

                string output = reader.ReadToEnd();

                //full list of books as string lines
                string[] lines = output.Split('\n');

                reader.Close();

                //This sets the location of the chosen array to be equal to the new status converted string
                lines[index - 1] = newline;

                string newupdatedstatuslist = string.Join("\n", lines);


                StreamWriter writer = new StreamWriter(filePath);
                //Write override everything with the string
                writer.Write(newupdatedstatuslist);

                writer.Close();

            }
            else
            {
                Console.WriteLine($"{chosenbook.Title}, by {chosenbook.Author} is currently checked out, its due back by the {chosenbook.DueDate}");
            }



        }

        public void CheckOut(int index, List<Books> BookList, List<Books> OGList)
        {
            Books chosenbook = BookList[index - 1];

            if (chosenbook.Status == true)
            {
                //sets the dueDate 14 days ahead from the current system time

                int chosenbookogindex=-1;

                for (int i = 0; i < OGList.Count; i++)
                {
                    if (chosenbook.Title==OGList[i].Title&& chosenbook.Author == OGList[i].Author)
                    {
                        chosenbookogindex = i;
                    }
                }

                DateTime dueDate = DateTime.Now.AddDays(14);
                chosenbook.DueDate = chosenbook.DateToString(dueDate);
                Console.WriteLine($"You have checked out {chosenbook.Title}, by {chosenbook.Author} Please bring it back by {dueDate}");
                
                chosenbook.Status = false;

                //takes updated b and turns it to a string.
                string newline = LIbraryIO.BooksToString(chosenbook);

                //Repulls the whole list from the text file into program

                string filePath = @"..\..\..\BooksList.txt";
                StreamReader reader = new StreamReader(filePath);

                string output = reader.ReadToEnd();

                //full list of books as string lines
                string[] lines = output.Split('\n');

                reader.Close();

                //This sets the location of the chosen array to be equal to the new status converted string
                lines[chosenbookogindex - 1] = newline;

                string newupdatedstatuslist = string.Join("\n", lines);


                StreamWriter writer = new StreamWriter(filePath);
                //Write override everything with the string
                writer.Write(newupdatedstatuslist);

                writer.Close();

            }
            else
            {
                Console.WriteLine($"{chosenbook.Title}, by {chosenbook.Author} is currently checked out, its due back by the {chosenbook.DueDate}");
            }



        }

        public void ReturnBook(int index)
        {
            Books chosenbook = BookList[index - 1];


            
            if (chosenbook.Status != true)
            {
                //sets the dueDate back to null
                
                chosenbook.DueDate = null;
                Console.WriteLine($"You have returned {chosenbook.Title}, by {chosenbook.Author} Thank You!");

                //this updates the bool to read as on shelf
                chosenbook.Status = true;

                //takes updated chosenbook and turns it to a string.
                string newline = LIbraryIO.BooksToString(chosenbook);

                //Repulls the whole list from the text file into program

                string filePath = @"..\..\..\BooksList.txt";
                StreamReader reader = new StreamReader(filePath);

                string output = reader.ReadToEnd();

                string[] lines = output.Split('\n');

                reader.Close();

                //This sets the location of the chosen array to be equal to the new status converted string
                lines[index - 1] = newline;

                string newupdatedstatuslist = string.Join("\n", lines);


                StreamWriter writer = new StreamWriter(filePath);
                //Write override everything with the string
                writer.Write(newupdatedstatuslist);

                writer.Close();

            }
            else
            {
                Console.WriteLine($"{chosenbook.Title}, by {chosenbook.Author} is currently on file and doesn't need to be returned");
            }


        }



        //this will search the book list for an author and check to see if that author is in the book list
        public void SearchbyAuthor(List<Books> booklist, string keyword)
        {
            var byTitleAuthor = booklist.Where(Book => Book.Author.Contains(keyword) || Book.Title.Contains(keyword));
            Console.WriteLine(byTitleAuthor);
            foreach (Books book in byTitleAuthor)
            {
                Console.WriteLine(book.Title + book.Author);
            }
        }

    }
}