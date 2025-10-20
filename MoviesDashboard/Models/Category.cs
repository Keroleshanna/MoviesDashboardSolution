using MoviesDashboard.Models.Common;

namespace MoviesDashboard.Models
{
    public class Category : BaseAuditableEntity<int>
    {
        public string Name { get; set; }
        public bool Status { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}