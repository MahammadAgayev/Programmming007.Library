using Programming007.LibraryCore;
using Programmming007.LibraryUI.Commands.BooksCommands;
using Programmming007.LibraryUI.Mappers;
using Programmming007.LibraryUI.Models.BookModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Programmming007.LibraryUI.ViewModels
{
    public class BooksUserControlViewModel : BaseUserControlViewModel
    {
        public BooksUserControlViewModel()
        {
            var books = Kernel.DB.BookRepository.Get();

            foreach (var item in books)
            {
                var model = BookMapper.MapToModel(item);
                Books.Add(model);
            }

            OpenAddBook = new OpenAddBookCommand(this);
            OpenEditBook = new OpenEditBookCommand(this);
            OpenRemoveBook = new RemoveBookCommand(this);
            ExportToExcel = new ExportToExcelCommand(this);
        }

        public ObservableCollection<BookModel> Books { get; set; } = new ObservableCollection<BookModel>();
        public BookModel SelectedBook { get; set; }

        public ICommand OpenAddBook { get; set; }
        public ICommand OpenEditBook { get; set; }
        public ICommand OpenRemoveBook { get; set; }
        public ICommand ExportToExcel { get; set; }
    }
}
