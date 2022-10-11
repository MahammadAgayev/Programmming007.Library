using Programmming007.LibraryUI.Commands.DbConfigurationCommands;
using Programmming007.LibraryUI.Models.Configs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Programmming007.LibraryUI.ViewModels
{
    public class DbConfigurationViewModel : BaseWindowViewModel
    {
        public DbConfigurationViewModel()
        {
            Save = new SaveConfigurationCommand(this);
            Cancel = new CancelConfigurationCommand(this);
        }

        public ICommand Save { get; set; }
        public ICommand Cancel { get; set; }

        public DatabaseConfigModel Config { get; set; } = new DatabaseConfigModel();
    }
}
