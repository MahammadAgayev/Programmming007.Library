using Programming007.LibraryCore;
using Programmming007.LibraryUI.Helpers;
using Programmming007.LibraryUI.Mappers;
using Programmming007.LibraryUI.ViewModels;
using Programmming007.LibraryUI.Windows;
using System;
using System.Linq;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.BooksCommands
{
    public class OpenEditBookCommand : ICommand
    {
        private readonly BooksUserControlViewModel _viewModel;
        private readonly AuthorDbHelper _authorHelper;

        
        public OpenEditBookCommand(BooksUserControlViewModel viewModel)
        {
            _viewModel = viewModel;
            _authorHelper = new AuthorDbHelper();
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var window = new SaveBookWindow();
            var viewModel = new SaveBookWindowWiewModel();

            var book = Kernel.DB.BookRepository.Get(_viewModel.SelectedBook.Id);
            viewModel.BookModel = BookMapper.MapToDetailedModel(book);

            viewModel.Window = window;
            window.DataContext = viewModel;

            var authors = _authorHelper.Get();
            viewModel.Authors.Clear();

            foreach (var item in authors)
            {
                if (viewModel.BookModel.SelectedAuthors.Any(x => x.Id == item.Id))
                    continue;

                viewModel.Authors.Add(item);
            }

            window.ShowDialog();

            _viewModel.Books.Clear();

            var books = Kernel.DB.BookRepository.Get();
            foreach (var item in books)
            {
                var model = BookMapper.MapToModel(item);
                _viewModel.Books.Add(model);
            }
        }
    }
}
