using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataModel.Classes;
using FileProcessor;

namespace FileProcessor
{
    public class FileParser : IFileParser
    {
        private string _fileName;
        private IBaseFile _fileInstance;

        public IEnumerable<IBaseFile> ParseFile(string fileName, IBaseFile fileInstance)
        {
            try
            {
                _fileName = fileName;
                _fileInstance = fileInstance;
                if (string.IsNullOrEmpty(fileName))
                    return null;
                if (!System.IO.File.Exists(fileName))
                    return null;
                return Read();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
        
        private IEnumerable<IBaseFile> Read()
        {
            var objects = new List<IBaseFile>();
            using (var sr = new StreamReader(_fileName))
            {
                bool headersRead = false;
                string line;
                string[] headers = null;
                do
                {
                    line = sr.ReadLine();
                    if (line != null && headersRead)
                    {
                       var instance =  Activator.CreateInstance(_fileInstance.GetType());
                        var propertyValues = line.Split(',');
                        AssignValuesFromCsv(propertyValues,headers, instance);
                        objects.Add((IBaseFile)instance);
                    }
                    if (!headersRead)
                    {
                        headers = line?.Split(',');
                        headersRead = true;
                    }
                }
                while (line != null);
            }
            return objects;
        }

        private void AssignValuesFromCsv(string[] propertyValues,string[] headers, object instance)
        {
            var properties = _fileInstance.GetType().GetProperties().ToDictionary(p => p.Name.ToLower());
            for (int i = 0; i < headers.Length; i++)
            {
                var key = headers[i].Replace(" ", string.Empty).Replace("/",string.Empty).ToLower();
                if (properties.Keys.Contains(key))
                {
                    var type = properties[key].PropertyType.Name;
                    switch (type)
                    {
                        case "Int32":
                            properties[key].SetValue(instance, int.Parse(propertyValues[i]));
                            break;
                        case "Long":
                            properties[key].SetValue(instance, long.Parse(propertyValues[i]));
                            break;
                        case "Double":
                            properties[key].SetValue(instance, double.Parse(propertyValues[i]));
                            break;
                        case "Boolean":
                            properties[key].SetValue(instance, Boolean.Parse(propertyValues[i]));
                            break;
                        case "DateTime":
                            properties[key].SetValue(instance, DateTime.Parse(propertyValues[i]));
                            break;
                        default:
                            properties[key].SetValue(instance, propertyValues[i]);
                            break;
                    }
                }
            }
         
        }
    }
}
