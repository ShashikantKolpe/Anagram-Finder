using System;
using System.Collections.Generic;
using System.Linq;

namespace Anagram_Finder
{

    public class Base
    {
        public interface IFilters
        {
            string Name { get; }
            IEnumerable<string> FilterContent(IEnumerable<string> wordList, UserFilters filterModel);

        }
        public class Anagram : IFilters
        {
            public string Name => "AnagramFilter";

            public IEnumerable<string> FilterContent(IEnumerable<string> wordList, UserFilters userFilters)
            {
                if (string.IsNullOrEmpty(userFilters.InputAnagram) || wordList == null)
                    return wordList;

                List<string> result = new List<string>();                 
                var listOfChars = string.Concat(userFilters.InputAnagram.ToCharArray().OrderBy(input => input));

                foreach (var word in wordList)
                {
                    if (string.IsNullOrEmpty(word))
                        continue;

                    if (string.Equals(string.Concat(word.ToCharArray().OrderBy(input => input)), listOfChars, StringComparison.OrdinalIgnoreCase))
                        result.Add(word);
                }

                return result;
            }

        }


    }
}

