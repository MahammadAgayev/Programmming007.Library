using Programming007.LibraryCore;
using Programming007.LibraryCore.Domain.Enums;
using Programmming007.LibraryUI.Commands.BooksCommands;
using Programmming007.LibraryUI.Helpers;
using Programmming007.LibraryUI.Mappers;
using Programmming007.LibraryUI.Models.AuthorModels;
using Programmming007.LibraryUI.Models.BookModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Programmming007.LibraryUI.ViewModels
{
    public class SaveBookWindowWiewModel : BaseWindowViewModel
    {
        private readonly AuthorDbHelper _authorHelper;
        public SaveBookWindowWiewModel()
        {
            _authorHelper = new AuthorDbHelper();
            var authors = _authorHelper.Get();

            foreach (var item in authors)
            {
                Authors.Add(item);
            }

            var genres = Enum.GetValues(typeof(Genre)).Cast<Genre>();

            foreach (var item in genres)
            {
               GenreList.Add(item);
            }

            SaveBook = new SaveBookCommand(this);
            MoveAuthorDown = new MoveAuthorDownCommand(this);
            MoveAuthorUp = new MoveAuthorUpCommand(this);
        }

        public BookDetailedModel BookModel { get; set; } = new BookDetailedModel();
        public AuthorModel SelectedAuthorToDown { get; set; } = new AuthorModel();
        public AuthorModel SelectedAuthorToUp { get; set; } = new AuthorModel();

        public ObservableCollection<Genre> GenreList { get; set; } = new ObservableCollection<Genre>();
        public ObservableCollection<AuthorModel> Authors { get; set; } = new ObservableCollection<AuthorModel>();


        public ICommand MoveAuthorUp { get; set; }
        public ICommand MoveAuthorDown { get; set; }
        public ICommand SaveBook { get; set; }
    }
}
