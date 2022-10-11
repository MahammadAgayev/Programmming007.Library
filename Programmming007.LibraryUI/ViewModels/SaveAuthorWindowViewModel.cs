using Programmming007.LibraryUI.Commands.MainWindowCommands;
using Programmming007.LibraryUI.Models.AuthorModels;
using System.Windows.Input;

namespace Programmming007.LibraryUI.ViewModels
{
    public class SaveAuthorWindowViewModel : BaseWindowViewModel
    {
        public SaveAuthorWindowViewModel()
        {
            SaveAuthor = new SaveAuthorCommand(this);
        }

        public AuthorModel AuthorModel { get; set; } = new AuthorModel();

        public ICommand SaveAuthor { get; set; }
    }
}
