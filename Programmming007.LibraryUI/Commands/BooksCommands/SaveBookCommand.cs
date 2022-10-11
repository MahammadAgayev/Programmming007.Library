using Programming007.LibraryCore;
using Programming007.LibraryCore.Domain.Entities;
using Programmming007.LibraryUI.Mappers;
using Programmming007.LibraryUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.BooksCommands
{
    public class SaveBookCommand : ICommand
    {
        private readonly SaveBookWindowWiewModel _viewModel;

        public SaveBookCommand(SaveBookWindowWiewModel viewModel)
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
            var book = BookMapper.MapToEntity(_viewModel.BookModel);

            if(book.Id > 0)
            {
                Kernel.DB.BookRepository.Update(book);

                Kernel.DB.AuthorBookRepository.DeleteByBook(book.Id);
            }
            else
            {
                Kernel.DB.BookRepository.Add(book);
            }

            foreach (var item in book.Authors)
            {
                Kernel.DB.AuthorBookRepository.Add(new AuthorBook
                {
                    Author = item,
                    Book = book
                });
            }

            _viewModel.Window.Close();
        }
    }
}
