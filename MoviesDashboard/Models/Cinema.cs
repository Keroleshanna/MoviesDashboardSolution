
using MoviesDashboard.Models.Common;

namespace MoviesDashboard.Models
{
    public class Cinema : BaseAuditableEntity<int>
    {
        public string Name { get; set; }
        public string? Img { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
