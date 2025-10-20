using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesDashboard.Models;

namespace MoviesDashboard.ViewModels
{
    public class MovieVM
    {
        public Movie? Movie { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }
        public IEnumerable<SelectListItem>? Cinemas { get; set; }
    }
}
