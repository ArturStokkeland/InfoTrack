using Microsoft.EntityFrameworkCore;
using HistoryService.Domain.Entities;

namespace HistoryService.Infrastructure.HistoryDBContext
{
    public class HistoryDBContext : DbContext
    {
        public HistoryDBContext(DbContextOptions<HistoryDBContext> options) : base(options) { }

        public DbSet<History> History { get; set; }
    }
}
