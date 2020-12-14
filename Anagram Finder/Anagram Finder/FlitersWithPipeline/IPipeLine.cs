using System;
using System.Collections.Generic;

namespace Anagram_Finder
{
    interface IPipeLine
    {
        IEnumerable<string> Process(IEnumerable<string> input, UserFilters userFilters);
        void RegisterFilter(Base.IFilters module);
    }
    public static class PipelineFactory
    {
        public static PipeLine Instance()
        {
            var _pipeline = new PipeLine();
            _pipeline.RegisterFilter(new Base.Anagram());
            return _pipeline;
        }      
    }

}
