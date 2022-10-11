using Programmming007.LibraryUI.Constants;
using Programmming007.LibraryUI.Utils;
using Programmming007.LibraryUI.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Programmming007.LibraryUI.Commands.AuthorCommands
{
    public class ExportToExcelCommand : ICommand
    {
        private readonly AuthorUserControlViewModel _viewModel;

        public ExportToExcelCommand(AuthorUserControlViewModel viewModel)
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
            //StringBuilder s = new StringBuilder();

            //// string report = "Id,Name,Surname,Email\n";
            //s.AppendLine("Id, Name, Surname, Email");

            //foreach(var item in _viewModel.Authors)
            //{
            //    //report += $"{item.Id},{item.Name},{item.Surname},{item.Email}\n";
            //    s.AppendLine($"{item.Id},{item.Name},{item.Surname},{item.Email}");
            //}

            string filename = GenerateFileName();
            string path = Path.Combine(SystemDefaults.ReportPath, filename);
            //File.WriteAllText(path, s.ToString());

            CsvExporter.Export(_viewModel.Authors.ToArray(), path);

            MessageBox.Show($"Successfully exported to \"{path}\"", "Exported", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private string GenerateFileName()
        {
            return $"authors_{DateTime.Now:yyyy-MM-dd}.csv";
        }
    }
}
