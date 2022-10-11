using System;
using System.Collections.Generic;
using System.Text;

namespace Programmming007.LibraryUI.Models.Configs
{
    public class DatabaseConfigModel
    {
        public string Database { get; set; }
        public string Server { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
