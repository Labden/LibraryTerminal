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
    }
}
    
