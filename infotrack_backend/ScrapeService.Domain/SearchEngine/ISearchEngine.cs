using ScrapeService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapeService.Domain.SearchEngine
{
    public interface ISearchEngine
    {
        SearchEngineType searchEngineType { get; }
        string baseURL { get; }
        string searchTerm { get; }
        string separatorStart { get; }
        string separatorEnd { get; }

        string GetURLQuery();
        History GetRankings(string result);
    }
}
