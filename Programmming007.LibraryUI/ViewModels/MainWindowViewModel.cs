using Programmming007.LibraryUI.Commands.MainWindowCommands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Programmming007.LibraryUI.ViewModels
{
    public class MainWindowViewModel : BaseWindowViewModel
    {
        public MainWindowViewModel()
        {
            ShowAuthors = new ShowAuthorsCommand(this);
            ShowBooks = new ShowBooksCommand(this);
        }

        public ICommand ShowAuthors { get; set; }
        public ICommand ShowBooks { get; set; }
        public Grid Grid { get; set; }
    }
}
