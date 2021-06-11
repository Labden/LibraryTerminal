using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTerminal
{
    class Library
    {
        public List<Books> BookList { get; set; } = new List<Books>();

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
    }
}
