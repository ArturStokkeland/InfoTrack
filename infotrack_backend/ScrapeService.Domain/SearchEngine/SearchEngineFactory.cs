namespace ScrapeService.Domain.SearchEngine
{
    public static class SearchEngineFactory
    {
        public static ISearchEngine CreateSearchEngine(string searchEngineType, string searchTerm)
        {
            switch (searchEngineType)
            {
                case "google":
                    return new Google(searchTerm);
                case "bing":
                    return new Bing(searchTerm);
                default:
                    throw new ArgumentOutOfRangeException($"{searchEngineType} is not a valid or supported search engine");
            }

        }
    }
}
