using Programming007.LibraryCore.Domain.Abstract;
using Programming007.LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Programming007.LibraryCore.DataAccesLayer.SqlServer
{
    public class SqlBookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public SqlBookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO [dbo].[Books]
           ([Name]
           ,[ReleaseDate]
           ,[PageCount]
           ,[Genre]
           ,[ISBN]
           ,[PublishingHouse]) output inserted.id
     VALUES
           (@name
           ,@releaseDate
           ,@pageCount
           ,@genre
           ,@isbn
           ,@publishingHouse)";

                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("name", book.Name);
                cmd.Parameters.AddWithValue("releaseDate", book.ReleaseDate);
                cmd.Parameters.AddWithValue("pageCount", book.PageCount);
                cmd.Parameters.AddWithValue("genre", book.Genre);
                cmd.Parameters.AddWithValue("isbn", book.ISBN ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("publishingHouse", book.PublishingHouse);

                book.Id = (int)cmd.ExecuteScalar();
            }
        }

        public void Update(Book book)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"UPDATE [dbo].[Books]
   SET [Name] = @name
      ,[ReleaseDate] = @releaseDate
      ,[PageCount] = @pageCount
      ,[Genre] = @genre
      ,[ISBN] = @isbn
      ,[PublishingHouse] = @publishingHouse
 WHERE id = @id";

            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", book.Id);
            cmd.Parameters.AddWithValue("name", book.Name);
            cmd.Parameters.AddWithValue("releaseDate", book.ReleaseDate);
            cmd.Parameters.AddWithValue("pageCount", book.PageCount);
            cmd.Parameters.AddWithValue("genre", book.Genre);
            cmd.Parameters.AddWithValue("isbn", book.ISBN ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("publishingHouse", book.PublishingHouse);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "delete from books where id = @id";
                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Book Get(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
select b.*, 
a.Id as AuthorId, 
a.Name as AuthorName,
a.Surname as AuthorSurname, 
a.Email as AuthorEmail
from Books b
left join AuthorBooks ab on ab.BookId = b.Id
left join Authors a on a.Id = ab.AuthorId
where b.id = @id";
            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            var reader = cmd.ExecuteReader();

            //System.LINQ
            return ReadBooks(reader).FirstOrDefault();
        }

        public IList<Book> Get()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
select b.*, 
a.Id as AuthorId, 
a.Name as AuthorName,
a.Surname as AuthorSurname, 
a.Email as AuthorEmail
from Books b
left join AuthorBooks ab on ab.BookId = b.Id
left join Authors a on a.Id = ab.AuthorId";
            var cmd = new SqlCommand(query, connection);

            var reader = cmd.ExecuteReader();

            return ReadBooks(reader);
        }

        private IList<Book> ReadBooks(IDataReader reader)
        {
            var books = new List<Book>();

            while (reader.Read())
            {
                var book = Mapper.MapToBook(reader);

                Book alreadAdded = books.FirstOrDefault(x => x.Id == book.Id);
                if (alreadAdded == null)
                {
                    books.Add(book);
                    alreadAdded = book;
                }

                //normal
                //var author = new Author
                //{
                //    Id = reader.Get<int>("AuthorId"),
                //    Name = reader.Get<string>("AuthorName"),
                //    Surname = reader.Get<string>("AuthorSurname"),
                //    Email = reader.Get<string>("AuthorEmail")
                //};

                //more elegant way to do
                var author = Mapper.MapToAuthor(reader, "Author");
                alreadAdded.Authors.Add(author);
            }

            return books;
        }
    }
}
