using System.Collections.Generic;

namespace BookApp.Models.DbModels
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book> Books { get; set; }
        
        public Author() { }

        public Author(int authorId, string name, string surname)
        {
            AuthorId = authorId;
            Name = name;
            Surname = surname;
            Books = new List<Book>();
        }
    }
}