
using System.Collections.Generic;

namespace Anagram_Finder
{
   public class PipeLine : IPipeLine
    {
        private List<Base.IFilters> _modules = new List<Base.IFilters>();

        private UserFilters _userFilters = new UserFilters();

        public IEnumerable<string> Process(IEnumerable<string> input, UserFilters userFilters)
        {
            foreach (var module in _modules)
            {             
                    input = module.FilterContent(input, userFilters);
            }

            return input;
        }     

        public void RegisterFilter(Base.IFilters module)
        {
            _modules.Add(module);
        }
    }
}
