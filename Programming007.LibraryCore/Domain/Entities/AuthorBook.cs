using System;
using System.Collections.Generic;
using System.Text;

namespace Programming007.LibraryCore.Domain.Entities
{
    public class AuthorBook
    {
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
