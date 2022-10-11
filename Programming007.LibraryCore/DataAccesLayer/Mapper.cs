using Programming007.LibraryCore.Domain.Entities;
using Programming007.LibraryCore.Domain.Enums;
using System;
using System.Data;

namespace Programming007.LibraryCore.DataAccesLayer
{
    public static class Mapper
    {
        public static User MapToUser(IDataReader reader)
        {
            return new User
            {
                Id = reader.Get<int>("Id"),
                PasswordHash = reader.Get<string>("PasswordHash"),
                Username = reader.Get<string>("Username")
            };
        }

        public static Author MapToAuthor(IDataReader reader, string prefix = "")
        {
            return new Author
            {
                Id = reader.Get<int>(prefix + "Id"),
                Name = reader.Get<string>(prefix + "Name"),
                Surname = reader.Get<string>(prefix + "Surname"),
                Email = reader.Get<string>(prefix + "Email")
            };
        }

        public static Book MapToBook(IDataReader reader)
        {
            return new Book
            {
                Id = reader.Get<int>("Id"),
                Name = reader.Get<string>("Name"),
                ISBN = reader.Get<string>("Isbn"),
                Genre = reader.Get<Genre>("Genre"),
                PageCount = reader.Get<int>("PageCount"),
                PublishingHouse = reader.Get<string>("PublishingHouse"),
                ReleaseDate = reader.Get<DateTime>("ReleaseDate")
            };
        }
    }

    public static class DataReaderExtensions
    {
        public static T Get<T>(this IDataReader reader, string columnName)
        {
            var value = reader[columnName];

            if(value is DBNull)
            {
                return default;
            }

            return (T)reader[columnName];
        }
    }
}
