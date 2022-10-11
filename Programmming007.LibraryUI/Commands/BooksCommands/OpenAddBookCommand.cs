using Programming007.LibraryCore;
using Programmming007.LibraryUI.Mappers;
using Programmming007.LibraryUI.ViewModels;
using Programmming007.LibraryUI.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.BooksCommands
{
    public class OpenAddBookCommand : ICommand
    {
        private readonly BooksUserControlViewModel _viewModel;

        public OpenAddBookCommand(BooksUserControlViewModel viewModel)
        {
            _viewModel = viewModel;
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
            viewModel.Window = window;
            window.DataContext = viewModel;

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
