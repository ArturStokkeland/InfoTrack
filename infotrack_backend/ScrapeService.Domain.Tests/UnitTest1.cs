using ScrapeService.Domain.SearchEngine;

namespace ScrapeService.Domain.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("google", SearchEngineType.Google)]
        [InlineData("bing", SearchEngineType.Bing)]
        public void Should_Create_Correct_Engine_Type(string engine, SearchEngineType engineType)
        {
            var searchEngine = SearchEngineFactory.CreateSearchEngine(engine, "test");
            Assert.Equal(engineType, searchEngine.searchEngineType);
        }

        [Theory]
        [InlineData("google", "land registry search", "https://www.google.co.uk/search?num=100&q=land+registry+search")]
        [InlineData("bing", "land registry search", "https://www.bing.com/search?count=50&responseFilter=Webpages&q=land%20registry%20search")]
        public void Should_Create_Correct_URL(string engine, string searchTerm, string correctSearchTerm)
        {
            var searchEngine = SearchEngineFactory.CreateSearchEngine(engine, searchTerm);
            Assert.Equal(correctSearchTerm, searchEngine.GetURLQuery());
        }
    }
}