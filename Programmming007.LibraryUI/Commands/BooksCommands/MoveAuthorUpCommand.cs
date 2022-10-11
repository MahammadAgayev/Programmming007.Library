using Programmming007.LibraryUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.BooksCommands
{
    public class MoveAuthorUpCommand : ICommand
    {
        private readonly SaveBookWindowWiewModel _viewModel;

        public MoveAuthorUpCommand(SaveBookWindowWiewModel viewModel)
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
            _viewModel.Authors.Add(_viewModel.SelectedAuthorToUp);
            _viewModel.BookModel.SelectedAuthors.Remove(_viewModel.SelectedAuthorToUp);
        }
    }
}
