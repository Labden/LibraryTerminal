using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryTerminal
{
    public class Books
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public bool Status { get; set; }

        public string DueDate { get; set; }


        public Books(string Title, string Author, bool Status, string DueDate)
        {
            this.Title = Title;
            this.Author = Author;
            this.Status = Status;
            this.DueDate = DueDate;
        }

        //The checkout method is made to be called after a user has selected the book they wish the checkout
        //It then checks the books current availability status 
        public void CheckOut()
        {
            if (this.Status != false)
            {
                //sets the dueDate 14 days ahead from the current system time
                DateTime dueDate = DateTime.Now.AddDays(14);
                this.DueDate = DateToString(dueDate);

                Console.WriteLine($"You have checked out {this.Title}, by {this.Author} Please bring it back by {this.DueDate}");
                this.Status = false;

            }
            else
            {
                Console.WriteLine($"I'm sorry this book is currently checked out, its due back by the {this.DueDate}");
            }
        }


            public string DateToString(DateTime dateTime)
        {
            string dateTimeString = dateTime.ToString();
            return dateTimeString;

        }

        public  DateTime StringtoDate(string dateTimeString)
        {
            DateTime datetime = DateTime.Parse(dateTimeString);
            return datetime;
        }


        public static string BookToString(Books b)
        {
            string output = $"{b.Title}, {b.Author}, {b.DueDate},{b.Status}, \n";
            return output;
        }

        //This takes a string from our file and makes it into an object 
        public virtual Books ConvertToBook(string line)
        {
            string[] properties = line.Split(',');
            

            if (properties.Length == 4)
            {

                bool bstatus = bool.Parse(properties[2]);
                Books b = new Books(properties[0], properties[1], bstatus, null);
                return b;
            }
            else
            {
                return null;
            }


        }




    }
}
    
