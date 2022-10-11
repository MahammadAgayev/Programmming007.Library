using Programming007.LibraryCore.Domain.Entities;
using System.Collections.Generic;

namespace Programming007.LibraryCore.Domain.Abstract
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        void Update(Author author);

        IList<Author> Get();
        Author Get(int id);

        void Delete(int id);
    }
}
