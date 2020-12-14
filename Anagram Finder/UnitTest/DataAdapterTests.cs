using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Anagram_Finder;

namespace UnitTest
{
    public class DataAdapterTests
    {
        Mock<IDataStore> _mockDataStore = new Mock<IDataStore>();
        private readonly MockRepository _mockRepository;

        public DataAdapterTests()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockDataStore = _mockRepository.Create<IDataStore>();
        }

        private DataAdapter CreateDataAdapter()
        {
            return new DataAdapter(
                _mockDataStore.Object
                );
        }

        [Fact]
        public async void DataAdapter_Should_Success()
        {
            var dataAdapter = this.CreateDataAdapter();
            _mockDataStore.Setup(ds => ds.GetFileData(It.IsAny<string>()))
                .ReturnsAsync(
                new List<string>()
                {
                    "rat",
                    "art"
                });
            var result = dataAdapter.ReadFile("FileName");
            Assert.NotNull(result);
        }
    }
}
