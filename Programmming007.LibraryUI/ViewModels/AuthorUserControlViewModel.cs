using Programming007.LibraryCore;
using Programmming007.LibraryUI.Commands.AuthorCommands;
using Programmming007.LibraryUI.Models.AuthorModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Programmming007.LibraryUI.ViewModels
{
    public class AuthorUserControlViewModel : BaseUserControlViewModel
    {
        public AuthorUserControlViewModel()
        {
            var authors = Kernel.DB.AuthorRepository.Get();

            Authors = new ObservableCollection<AuthorModel>();

            foreach (var item in authors)
            {
                //object mapping
                var authorModel = new AuthorModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Email = item.Email
                };

                Authors.Add(authorModel);
            }

            OpenAddAuthor = new OpenAddAuthorCommand(this);
            RemoveAuthor = new RemoveAuhtorCommand(this);
            OpenEditAuthor = new OpenEditAuthorCommand(this);
            ExportToExcel = new ExportToExcelCommand(this);
        }

        public ObservableCollection<AuthorModel> Authors { get; set; }
        public AuthorModel SelectedAuthor { get; set; }

        public ICommand OpenAddAuthor { get; set; }
        public ICommand RemoveAuthor { get; set; }
        public ICommand OpenEditAuthor { get; set; }
        public ICommand ExportToExcel { get; set; }
    }
}
