using ScrapeService.Domain.Entities;

namespace ScrapeService.Domain.SearchEngine
{
    class Bing : ISearchEngine
    {
        public SearchEngineType searchEngineType { get; private set; }

        public string baseURL { get; private set; }

        public string searchTerm { get; private set; }

        public string separatorStart { get; private set; }
        public string separatorEnd { get; private set; }

        public Bing(string mySearchTerm)
        {
            searchEngineType = SearchEngineType.Bing;
            baseURL = "https://www.bing.com/search?count=50&responseFilter=Webpages&q=";
            searchTerm = mySearchTerm;
            separatorStart = "<cite>";
            separatorEnd = "</cite>";
        }

        public string GetURLQuery()
        {
            return $"{baseURL}{searchTerm.Trim().Replace(" ", "%20")}";
        }

        public History GetRankings(string result)
        {
            List<string> rankings = new List<string>();

            string[] entries = result.Split(separatorStart);

            for (int i = 1; i < entries.Length; i++)
            {
                string url = entries[i].Split(separatorEnd)[0];
                if (url.ToLower().Contains("infotrack"))
                {
                    rankings.Add(i.ToString());
                }
            }

            History history = new History();
            history.SearchTerm = this.searchTerm;
            history.SearchEngine = this.searchEngineType.ToString();
            history.DateSearched = DateTime.Now;

            if (rankings.Count != 0)
            {
                history.Rankings = string.Join(", ", rankings);
            }
            else
            {
                history.Rankings = "0";
            }

            return history;
        }
    }
}
