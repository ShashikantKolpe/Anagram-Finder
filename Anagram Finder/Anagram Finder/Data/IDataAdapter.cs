using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anagram_Finder
{
    public interface IDataAdapter
    {
        Task<List<string>> ReadFile(string filePath);
    }
}
