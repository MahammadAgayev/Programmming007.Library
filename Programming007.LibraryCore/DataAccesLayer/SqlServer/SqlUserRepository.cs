using Programming007.LibraryCore.Domain.Abstract;
using Programming007.LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Programming007.LibraryCore.DataAccesLayer.SqlServer
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public SqlUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User Get(string username)
        {
            //using(SqlConnection connection = new SqlConnection(_connectionString))
            //{

            //}

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "select * from users where username  = @username";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("username", username);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == false)
                return null;

            //User user = Mapper.MapToUser(reader);

            //return user;

            return Mapper.MapToUser(reader);
        }
    }
}
