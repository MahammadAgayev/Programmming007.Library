using Programming007.LibraryCore.Domain.Abstract;
using System.Data.SqlClient;

namespace Programming007.LibraryCore.DataAccesLayer.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;

        public SqlUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IUserRepository UserRepository => new SqlUserRepository(_connectionString);
        public IAuthorRepository AuthorRepository => new SqlAuthorRepository(_connectionString);
        public IBookRepository BookRepository => new SqlBookRepository(_connectionString);
        public IAuthorBookRepository AuthorBookRepository => new SqlAuthorBookRepository(_connectionString);

        public bool CheckConnection()
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);

                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
