using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;

namespace LibraryTerminal
{
     public class Library
    {
        public List<Books> BookList { get; set; } = new List<Books>();
        public string Return { get; set; } = "Your book has been returned!";
        public Library()
        {
            BookList.Add(new Books("Game of Thrones","George R.R Martin", true, null));        //index 0
            BookList.Add(new Books("On the road", "Jack Kerouac", true, null));                //index 1
            BookList.Add(new Books("Green eggs an ham", "Dr.Seuess", true, null));             //index 2
            BookList.Add(new Books("The Art of War", "Sun Tzu", true, null));                  //index 3
            BookList.Add(new Books("C#: Beginners guide to OOP", "Grand Circus", true, null)); //index 4
            BookList.Add(new Books("The little engine that could", "Watty Piper", true, null));//index 5
            BookList.Add(new Books("Harry Potter", "J.K Rowling", true, null));                //index 6
            BookList.Add(new Books("JavaScript 101", "Grand Circus", true, null));             //index 7
            BookList.Add(new Books("Soft Skills 101", "Grand Circus", true, null));            //index 8
            BookList.Add(new Books("Marcus Aurelius: Meditations", "Penguin Classics", true, null)); //index 9
            BookList.Add(new Books("Clean Code", "Robert Cecil Martin", true, null));          //index 10
            BookList.Add(new Books("Where the sidewalk ends", "Shel Silversteins", true, null)); //index 11
            BookList.Add(new Books("Alice in Wonderland", "Charles Dodgson", true, null));     //index 12
        }
        public void ReturnBook()
        {
            if (true)
            {
                Console.WriteLine("Would you like to return a book? (y/n)");
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y" || answer == "YES")
                {
                    Console.WriteLine(Return);
                }
                else if (answer == "N" || answer == "NO")
                {
                    Console.WriteLine("Okay!");
                }
            }
        }



        public void SearchbyAuthor( string keyword)
        {



            var byAuthor = this.BookList.Where(Book => Book.Author.ToLower().Contains(keyword.ToLower()));

       
            foreach (Books book in byAuthor)
            {
                Console.WriteLine($"{book.Title} -- {book.Author}");
            }

        }

        public void SearchbyTitle(string keyword)
        {



            var byTitle = this.BookList.Where(Book => Book.Title.ToLower().Contains(keyword.ToLower()) );


            foreach (Books book in byTitle)
            {
                Console.WriteLine($"{book.Title} + {book.Author}");
            }

        }




    }
}
