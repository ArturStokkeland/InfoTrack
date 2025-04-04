using Microsoft.EntityFrameworkCore;
using ScrapeService.Domain.Entities;

namespace ScrapeService.Infrastructure.HistoryDBContext
{
    public class HistoryDBContext : DbContext
    {
        public HistoryDBContext(DbContextOptions<HistoryDBContext> options) : base(options) { }

        public DbSet<History> History { get; set; }
    }
}
