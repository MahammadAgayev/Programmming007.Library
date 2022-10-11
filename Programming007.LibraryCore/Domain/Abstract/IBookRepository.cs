using Programming007.LibraryCore.Domain.Entities;
using System.Collections.Generic;

namespace Programming007.LibraryCore.Domain.Abstract
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Update(Book book);
        void Delete(int id);

        Book Get(int id);
        IList<Book> Get();
    }
}
