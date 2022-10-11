using Programming007.LibraryCore.Domain.Enums;
using Programmming007.LibraryUI.Models.AuthorModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Programmming007.LibraryUI.Models.BookModels
{
    public class BookDetailedModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PageCount { get; set; }
        public Genre Genre { get; set; }
        public string ISBN { get; set; }
        public string PublishingHouse { get; set; }

        public ObservableCollection<AuthorModel> SelectedAuthors { get; set; } = new ObservableCollection<AuthorModel>();
    }
}