using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Programmming007.LibraryUI.Utils
{
    public static class CsvExporter
    {
        public static void ExportGeneric<T>(T[] datas, string exportPath) where T : class
        {
            var type = datas[0].GetType();

            StringBuilder sb = new StringBuilder();
            var props = type.GetProperties();
            props = FilterProps(props);

            string[] propNames = props.Select(x => x.Name).ToArray();
            string header = string.Join(",", propNames);

            sb.AppendLine(header);

            foreach (var item in datas)
            {
                bool isFirst = true;
                foreach (var prop in props)
                {
                    if (isFirst == false)
                    {
                        sb.Append(",");
                    }

                    sb.Append(prop.GetValue(item));

                    if (isFirst)
                        isFirst = false;
                }
                sb.AppendLine();
            }

            File.WriteAllText(exportPath, sb.ToString());
        }

        public static void Export(object[] datas, string exportPath)
        {
            var type = datas[0].GetType();

            for (int i = 1; i < datas.Length; i++)
            {
                if(type.FullName != datas[i].GetType().FullName)
                {
                    Console.WriteLine("Exported datas should be same type");
                }
            }

            StringBuilder sb = new StringBuilder();
            var props = type.GetProperties();
            props = FilterProps(props);

            string[] propNames = props.Select(x => x.Name).ToArray();
            string header = string.Join(",", propNames);

            sb.AppendLine(header);

            foreach (var item in datas)
            {
                bool isFirst = true;
                foreach (var prop in props)
                {
                    if(isFirst == false)
                    {
                        sb.Append(",");
                    }

                    sb.Append(prop.GetValue(item));

                    if (isFirst)
                        isFirst = false;
                }
                sb.AppendLine();
            }

            File.WriteAllText(exportPath, sb.ToString());
        }

        static PropertyInfo[] FilterProps(PropertyInfo[] infos)
        {
            var filteredInfos = new List<PropertyInfo>();
            foreach (var item in infos)
            {
                if (item.PropertyType.IsArray)
                    continue;
                else if (item.PropertyType.IsGenericType)
                    continue;

                filteredInfos.Add(item);
            }

            return filteredInfos.ToArray();
        }
    }
}
