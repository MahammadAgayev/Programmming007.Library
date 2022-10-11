using Programmming007.LibraryUI.UserControls;
using Programmming007.LibraryUI.ViewModels;
using System;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.MainWindowCommands
{
    public class ShowBooksCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public ShowBooksCommand(MainWindowViewModel viewModel)
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
            _viewModel.Grid.Children.Clear();

            var userControl = new BooksUserControl();
            var viewModel = new BooksUserControlViewModel();

            userControl.DataContext = viewModel;
            viewModel.UserControl = userControl;

            _viewModel.Grid.Children.Add(userControl);
        }
    }
}
