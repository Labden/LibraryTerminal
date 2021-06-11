using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTerminal
{
    class Library
    {
        public List<Books> Books { get; set; } = new List<Books>();

        public Library()
        {
            Books.Add(new Books("Game of Thrones","George R.R Martin", true, null));        //index 0
            Books.Add(new Books("On the road", "Jack Kerouac", true, null));                //index 1
            Books.Add(new Books("Green eggs an ham", "Dr.Seuess", true, null));             //index 2
            Books.Add(new Books("The Art of War", "Sun Tzu", true, null));                  //index 3
            Books.Add(new Books("C#: Beginners guide to OOP", "Grand Circus", true, null)); //index 4
            Books.Add(new Books("The little engine that could", "Watty Piper", true, null));//index 5
        }
    }
}
