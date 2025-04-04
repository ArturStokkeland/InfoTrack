using Microsoft.AspNetCore.Mvc;
using ScrapeService.Domain.SearchEngine;
using ScrapeService.Api.DTO;
using ScrapeService.Infrastructure.SearchEngineClient;
using ScrapeService.Infrastructure.HistoryDBContext;
using ScrapeService.Domain.Entities;

namespace ScrapeService.Api.Controllers
{
    [ApiController]
    [Route("scrape/[controller]")]
    public class ScrapeController : ControllerBase
    {
        private readonly SearchEngineClient _httpClient;
        private readonly HistoryDBContext _context;

        public ScrapeController(SearchEngineClient httpClient, HistoryDBContext historyDBContext)
        {
            _httpClient  = httpClient;
            _context = historyDBContext;
        }

        [HttpPost("/scrape")]
        public async Task<IActionResult> Scrape([FromBody] ScrapeRequest request)
        {
            ISearchEngine searchEngine = SearchEngineFactory.CreateSearchEngine(request.searchEngine, request.searchTerm);
            string searchResult = await _httpClient.GetSearchResult(searchEngine.GetURLQuery());
            History rankings = searchEngine.GetRankings(searchResult);
            _context.History.Add(rankings);
            _context.SaveChanges();
            return Ok(rankings);
        }
    }
}
