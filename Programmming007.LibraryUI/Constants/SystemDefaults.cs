using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Programmming007.LibraryUI.Constants
{
    public class SystemDefaults
    {
        public static string DbConfigPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "programming007.library.settings");

        private static string reportPath = "D:\\reports";
        public static string ReportPath
        {
            get
            {
                if (Directory.Exists(reportPath) == false)
                    Directory.CreateDirectory(reportPath);

                return reportPath;
            }
        }


    }
}
