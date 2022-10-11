using Programming007.LibraryCore;
using Programmming007.LibraryUI.Constants;
using Programmming007.LibraryUI.Mappers;
using Programmming007.LibraryUI.Utils;
using Programmming007.LibraryUI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.BooksCommands
{
    public class ExportToExcelCommand : ICommand
    {
        private readonly BooksUserControlViewModel _viewModel;

        public ExportToExcelCommand(BooksUserControlViewModel viewModel)
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
            var books = Kernel.DB.BookRepository.Get();

            //var sb = new StringBuilder();

            //sb.AppendLine("Id,Name,ReleaseDate,PageCount,ISBN,PublishingHouse");

            //foreach (var item in books)
            //{
            //    var model = BookMapper.MapToDetailedModel(item);

            //    sb.AppendLine($"{model.Id},{model.Name},{model.ReleaseDate:yyyy-MM-dd},{model.PageCount},{model.ISBN},{model.PublishingHouse}");
            //}

            //string filename = GenerateFileName();
            //string path = Path.Combine(SystemDefaults.ReportPath, filename);
            //File.WriteAllText(path, sb.ToString());


            string filename = GenerateFileName();
            string path = Path.Combine(SystemDefaults.ReportPath, filename);
            CsvExporter.Export(books.ToArray(), path);

            MessageBox.Show($"Successfully exported to \"{path}\"", "Exported", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private string GenerateFileName()
        {
            return $"books_{DateTime.Now:yyyy-MM-dd}.csv";
        }
    }
}
