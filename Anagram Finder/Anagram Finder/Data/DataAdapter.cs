using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anagram_Finder
{
    public class DataAdapter : IDataAdapter
    {
        private readonly IDataStore _dataStore;
        public DataAdapter(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }
        public async Task<List<string>> ReadFile(string filePath)
        {
            return await _dataStore.GetFileData(filePath);
        }
    }
}
