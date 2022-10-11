using Programming007.LibraryCore;
using Programming007.LibraryCore.Domain.Entities;
using Programmming007.LibraryUI.ViewModels;
using System;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.MainWindowCommands
{
    public class SaveAuthorCommand : ICommand
    {
        private readonly SaveAuthorWindowViewModel _viewModel;

        public SaveAuthorCommand(SaveAuthorWindowViewModel viewModel)
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
            var author = new Author
            {
                Name = _viewModel.AuthorModel.Name,
                Surname = _viewModel.AuthorModel.Surname,
                Email = _viewModel.AuthorModel.Email,
                Id = _viewModel.AuthorModel.Id,
            };

            if(author.Id > 0)
            {
                Kernel.DB.AuthorRepository.Update(author);
            }
            else
            {
                Kernel.DB.AuthorRepository.Add(author);
            }

            _viewModel.AuthorModel.Id = author.Id;
            _viewModel.Window.Close();
        }
    }
}
