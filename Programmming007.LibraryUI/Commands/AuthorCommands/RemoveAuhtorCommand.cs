using Programming007.LibraryCore;
using Programmming007.LibraryUI.UserControls;
using Programmming007.LibraryUI.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.AuthorCommands
{
    public class RemoveAuhtorCommand : ICommand
    {
        private readonly AuthorUserControlViewModel _viewModel;

        public RemoveAuhtorCommand(AuthorUserControlViewModel viewModel)
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

            if(res == MessageBoxResult.Yes)
            {
                Kernel.DB.AuthorRepository.Delete(_viewModel.SelectedAuthor.Id);
                _viewModel.Authors.Remove(_viewModel.SelectedAuthor);
            }
        }
    }
}
