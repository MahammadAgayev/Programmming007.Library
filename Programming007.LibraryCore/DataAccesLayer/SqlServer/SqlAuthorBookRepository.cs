using Programming007.LibraryCore.Domain.Abstract;
using Programming007.LibraryCore.Domain.Entities;
using System.Data.SqlClient;

namespace Programming007.LibraryCore.DataAccesLayer.SqlServer
{
    public class SqlAuthorBookRepository : IAuthorBookRepository
    {
        private readonly string _connectionString;

        public SqlAuthorBookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(AuthorBook authorBook)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "insert into authorbooks(AuthorId, BookId) values(@authorId, @bookId)";
            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("AuthorId", authorBook.Author.Id);
            cmd.Parameters.AddWithValue("BookId", authorBook.Book.Id);

            cmd.ExecuteNonQuery();
        }

        public void DeleteByBook(int bookId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "delete from authorbooks where bookId = @bookid";
            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("bookId", bookId);

            cmd.ExecuteNonQuery();
        }
    }
}
