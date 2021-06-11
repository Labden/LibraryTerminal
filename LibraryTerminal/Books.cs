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
        public  void CheckOut()
        {
            if (this.Status==true)
            {
                

                //sets the dueDate 14 days ahead from the current system time
                DateTime dueDate = DateTime.Now.AddDays(14);
                this.DueDate = DateToString(dueDate);
                this.Status = false;
                Console.WriteLine($"The book is available, Please bring it back by {dueDate}");

            }
            else
            {
                Console.WriteLine("I'm sorry this book is currently checked out");
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
    }
}
    
