namespace Programming007.LibraryCore.Domain.Abstract
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        IAuthorBookRepository AuthorBookRepository { get; }

        bool CheckConnection();
    }
}