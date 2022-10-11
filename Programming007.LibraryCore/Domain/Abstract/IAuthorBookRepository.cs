using Programming007.LibraryCore.Domain.Entities;

namespace Programming007.LibraryCore.Domain.Abstract
{
    public interface IAuthorBookRepository
    {
        void Add(AuthorBook authorBook);
        void DeleteByBook(int bookId);
    }
}