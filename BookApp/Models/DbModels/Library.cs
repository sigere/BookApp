using System.Collections.Generic;

namespace BookApp.Models.DbModels
{
    public class Library
    {
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }

        public Library() { }

        public Library(int libraryId, string name)
        {
            LibraryId = libraryId;
            Name = name;
            Books = new List<Book>();
        }
    }
}