using Programming007.LibraryCore;
using Programmming007.LibraryUI.Mappers;
using Programmming007.LibraryUI.Models.AuthorModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Programmming007.LibraryUI.Helpers
{
    public class AuthorDbHelper
    {
        public IList<AuthorModel> Get()
        {
            var authors = Kernel.DB.AuthorRepository.Get();

            var models = new List<AuthorModel>();
            foreach (var item in authors)
            {
                models.Add(AuthorMapper.MapToModel(item));
            }

            return models;
        }
    }
}
