using Programming007.LibraryCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Programming007.LibraryCore.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PageCount { get; set; }
        public Genre Genre { get; set; }
        public string ISBN { get; set; }
        public string PublishingHouse { get; set; }

        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
