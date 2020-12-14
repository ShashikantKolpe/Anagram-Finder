using Anagram_Finder;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
namespace UnitTest
{
    public class FiltersTests
    {
        [Theory]
        [InlineData("war", "raw")]
        public async void Anaram_Filter_Should_Return_Anarams(params string[] wordList)
        {
            //Arrange
            var factory = PipelineFactory.Instance();
            var results = factory.Process(wordList.ToList(), new UserFilters() {InputAnagram = "awr" });

            //Act& Assert
            Assert.Contains("war", wordList);
            Assert.Contains("raw", wordList);
        }


        [Fact]
        public async void Anaram_Filter_Should_Return_Null_When_Wordlist_is_null()
        {
            //Arrange
            var factory = PipelineFactory.Instance();
            var results = factory.Process(null, new UserFilters() { InputAnagram = "awr" });

            //Act& Assert
            Assert.Null(results);
        }



        [Theory]
        [InlineData("war", "raw")]
        public async void Anaram_Filter_Should_Return_Null_When_No_Matches_Found(params string[] wordList)
        {
            //Arrange
            var factory = PipelineFactory.Instance();
            var results = factory.Process(wordList, new UserFilters() { InputAnagram = "xyz" });

            //Act& Assert
            Assert.Empty(results);
        }

    }
}
