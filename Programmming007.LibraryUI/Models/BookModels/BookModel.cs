using Programming007.LibraryCore.Domain.Enums;

namespace Programmming007.LibraryUI.Models.BookModels
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public string AuthorName { get; set; }
    }
}
