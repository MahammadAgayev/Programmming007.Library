using System.Collections.Generic;

namespace Programming007.LibraryCore.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; }
        public string Email { get; set; }

        public List<Book> Books { get; set; }

        public string Fullname => $"{Name} {Surname}";
    }
}
