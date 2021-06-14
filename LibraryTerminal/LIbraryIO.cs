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



            public void SearchbyAuthor(string keyword)
            {
                var byAuthor = this.BookList.Where(Book => Book.Author.ToLower().Contains(keyword.ToLower()));

                foreach (Books book in byAuthor)
                {
                    Console.WriteLine($"{book.Title} -- {book.Author}");
                }

            }

            public void SearchbyTitle(string keyword)
            {



                var byTitle = this.BookList.Where(Book => Book.Title.ToLower().Contains(keyword.ToLower()));


                foreach (Books book in byTitle)
                {
                    Console.WriteLine($"{book.Title} + {book.Author}");
                }

            }

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
                writer.Write(original+ line);

                writer.Close();
            }

            public string BooksToString(Books b)
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
            Console.WriteLine();
            for (int i = 0; i < BookList.Count; i++)
            {

                if (BookList[i].Status == true)
                {
                    Console.WriteLine($"{i + 1}: {this.BookList[i].Title}, -- {this.BookList[i].Author}, On Shelf");
                    
                }
                else
                { Console.WriteLine($"{i + 1}: {this.BookList[i].Title}, -- {this.BookList[i].Author} due back by {this.BookList[i].DueDate}"); }

            }
            Console.WriteLine();
        }

        //uses current day and sets that date to the book property DueDate and sets a return by time
        public void CheckOut(Books b)
        {
            if (b.Status == true)
            {
                //sets the dueDate 14 days ahead from the current system time
                DateTime dueDate = DateTime.Now.AddDays(14);
                b.DueDate = b.DateToString(dueDate);
                Console.WriteLine($"You have checked out {b.Title}, by {b.Author} Please bring it back by {dueDate}");
                b.Status = false;
            }
            else
            {
                Console.WriteLine($"{b.Title}, by {b.Author} is currently checked out, its due back by the {b.DueDate}");
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

