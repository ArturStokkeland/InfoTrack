using HistoryService.Domain.Entities;
using HistoryService.Infrastructure.HistoryDBContext;
using Microsoft.AspNetCore.Mvc;

namespace HistoryService.Api.Controllers
{
    [ApiController]
    [Route("history/[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly HistoryDBContext _context;

        public HistoryController(HistoryDBContext historyDBContext)
        {
            _context = historyDBContext;
        }

        [HttpGet("/history")]
        public async Task<IActionResult> GetHistory()
        {
            List<History> history = _context.History.OrderByDescending(x => x.DateSearched).Take(10).ToList();
            return Ok(history);
        }
    }
}
