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
            List<string> shrekScenes = new List<string>() {};
            Books.Add(new Books());

            List<string> silentHillScenes = new List<string>() {};
            Books.Add(new Books());

            List<string> theNotebookScenes = new List<string>() {};
            Books.Add(new Books());

            List<string> pulpFictionScenes = new List<string>() {};
            Books.Add(new Books());

            List<string> fightClubScenes = new List<string>() {};
            Books.Add(new Books());

            List<string> pineappleExpressScenes = new List<string>() {};
            Books.Add(new Books());
        }
    }
}
