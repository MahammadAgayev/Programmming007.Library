using Newtonsoft.Json;
using Programmming007.LibraryUI.Constants;
using Programmming007.LibraryUI.Models.Configs;
using System.IO;

namespace Programmming007.LibraryUI.Utils
{
    public class ConfigHelper
    {
        public DatabaseConfigModel ReadFromFile()
        {
            if (File.Exists(SystemDefaults.DbConfigPath) == false)
                return null;

            string configData = File.ReadAllText(SystemDefaults.DbConfigPath);

            return JsonConvert.DeserializeObject<DatabaseConfigModel>(configData);
        }

        public void SaveToFile(DatabaseConfigModel databaseConfigModel)
        {
            string data = JsonConvert.SerializeObject(databaseConfigModel);

            File.WriteAllText(SystemDefaults.DbConfigPath, data);
        }
    }
}
