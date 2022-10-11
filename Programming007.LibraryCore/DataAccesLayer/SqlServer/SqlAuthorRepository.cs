using Programming007.LibraryCore.Domain.Abstract;
using Programming007.LibraryCore.Domain.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Programming007.LibraryCore.DataAccesLayer.SqlServer
{
    public class SqlAuthorRepository : IAuthorRepository
    {
        private readonly string _connectionString;

        public SqlAuthorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Author author)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "insert into authors(name, surname, email) output inserted.Id  values(@name, @surname, @email)";
                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("name", author.Name);
                cmd.Parameters.AddWithValue("surname", author.Surname);
                cmd.Parameters.AddWithValue("email", author.Email);

                var data = cmd.ExecuteScalar();
                author.Id = (int)data;
            }
        }

        /*
         * var author  = db.GetAuthor();
         * 
         * autor.Name = "Mahammad";
         * 
         * db.Update(author);
         */

        public void Update(Author author)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "update authors set name = @name, surname  = @surname, email = @email where id = @id";
                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("id", author.Id);
                cmd.Parameters.AddWithValue("name", author.Name);
                cmd.Parameters.AddWithValue("surname", author.Surname);
                cmd.Parameters.AddWithValue("email", author.Email);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "delete from authors where id = @id";
                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public IList<Author> Get()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "select * from authors";
                var cmd = new SqlCommand(query, connection);

                var authors = new List<Author>();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var author = Mapper.MapToAuthor(reader);

                    authors.Add(author);
                }

                return authors;
            }
        }

        public Author Get(int id)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "select * from authors where id = @id";

                var cmd = new SqlCommand(query, connection);
                var reader = cmd.ExecuteReader();

                if (reader.Read() == false)
                    return null;

                var author = Mapper.MapToAuthor(reader);

                return author;
            }
        }
    }
}
