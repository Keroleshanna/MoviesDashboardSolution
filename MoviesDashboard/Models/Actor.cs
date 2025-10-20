using MoviesDashboard.Models.Common;

namespace MoviesDashboard.Models
{
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
    public class Actor : BaseAuditableEntity<int>
    {
        public string Name { get; set; }
        public DateOnly? Birthday { get; set; }
        public Gender? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Img { get; set; }

         
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
