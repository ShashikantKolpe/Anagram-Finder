using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
namespace Anagram_Finder
{
    public class DataStore : IDataStore
    {
        public Task<List<string>> GetFileData(string path)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (var streamReader = new StreamReader(assembly.GetManifestResourceStream(path)))
                {
                    var fileData = streamReader.ReadToEnd();
                    if (fileData != null)
                    {
                        return Task.FromResult(fileData.Split('\n').ToList()); 
                    }

                    return Task.FromResult(default(List<string>));
                }
            }
            catch (Exception ex)
            {
                return Task.FromResult(default(List<string>));
            }
        }
    }
}
