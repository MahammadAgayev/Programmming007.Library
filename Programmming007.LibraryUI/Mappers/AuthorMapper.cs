using Programming007.LibraryCore.Domain.Entities;
using Programmming007.LibraryUI.Models.AuthorModels;

namespace Programmming007.LibraryUI.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorModel MapToModel(Author author)
        {
            return new AuthorModel
            {
                Id = author.Id,
                Surname = author.Surname,
                Email = author.Email,
                Name = author.Name
            };
        }
    }
}
