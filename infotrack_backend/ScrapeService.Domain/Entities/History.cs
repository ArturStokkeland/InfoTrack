using System.ComponentModel.DataAnnotations;

namespace ScrapeService.Domain.Entities
{
    public class History
    {
        [Key]
        public int ID { get; set; }
        public string Rankings { get; set; }
        public string SearchTerm { get; set; }
        public string SearchEngine { get; set; }
        public DateTime DateSearched { get; set; }
    }
}
