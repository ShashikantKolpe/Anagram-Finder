using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anagram_Finder
{
    public interface IDataStore
    {
        Task<List<string>> GetFileData(string path);
    }
}
