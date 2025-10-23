using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MoviesDashboard.Models.Common;

namespace MoviesDashboard.Models
{
    public class Movie : BaseAuditableEntity<int>
    {
        public string Name { get; set; }
        public string? Descrption { get; set; }
        public decimal? Price { get; set; }
        public bool Status { get; set; }
        public DateOnly? Date { get; set; }
        public TimeOnly? Time { get; set; }
        public string? MainImg { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        
        public int? CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        public ICollection<MovieImage> SubImages { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
