using Programming007.LibraryCore.Domain.Entities;
using Programmming007.LibraryUI.Models.BookModels;
using System.Collections.Generic;
using System.Linq;

namespace Programmming007.LibraryUI.Mappers
{
    public static class BookMapper
    {
        public static BookModel MapToModel(Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                AuthorName = string.Join('\n', book.Authors.Select(x => x.Fullname)),//book.Authors[0].Fullname,
                Genre = book.Genre,
                Name = book.Name,
            };
        }
        
        public static Book MapToEntity(BookDetailedModel model)
        {
            var book = new Book
            {
                Id = model.Id,
                ISBN = model.ISBN,
                Genre = model.Genre,
                Name = model.Name,
                PageCount = model.PageCount,
                PublishingHouse = model.PublishingHouse,
                ReleaseDate = model.ReleaseDate
            };

            var authors = new List<Author>();
            foreach (var item in model.SelectedAuthors)
            {
                var author = new Author
                {
                    Id = item.Id,
                    Surname = item.Surname,
                    Name = item.Name,
                    Email = item.Email,
                };

                authors.Add(author);
            }

            book.Authors = authors;

            return book;
        }

        public static BookDetailedModel MapToDetailedModel(Book book)
        {
            var model =  new BookDetailedModel
            {
                Id = book.Id,
                ISBN = book.ISBN,
                Genre = book.Genre,
                Name = book.Name,
                PageCount = book.PageCount,
                PublishingHouse = book.PublishingHouse,
                ReleaseDate = book.ReleaseDate,
            };

            foreach (var item in book.Authors)
            {
                var authorModel = AuthorMapper.MapToModel(item);
                model.SelectedAuthors.Add(authorModel);
            }

            return model;
        }
    }
}
