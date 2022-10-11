using Programming007.LibraryCore;
using Programmming007.LibraryUI.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.BooksCommands
{
    public class RemoveBookCommand : ICommand
    {
        private readonly BooksUserControlViewModel _viewModel;

        public RemoveBookCommand(BooksUserControlViewModel viewModel)
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
            var res = MessageBox.Show("Are you sure?", "Delete author", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (res == MessageBoxResult.Yes)
            {
                Kernel.DB.AuthorBookRepository.DeleteByBook(_viewModel.SelectedBook.Id);
                Kernel.DB.BookRepository.Delete(_viewModel.SelectedBook.Id);

                _viewModel.Books.Remove(_viewModel.SelectedBook);
            }
        }
    }
}
