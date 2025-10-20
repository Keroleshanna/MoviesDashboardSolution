using Microsoft.EntityFrameworkCore;
using MoviesDashboard.Models.Common;

namespace MoviesDashboard.Models
{
    [PrimaryKey(nameof(MovieId),nameof(ImageUrl))]
    public class MovieImage
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string ImageUrl { get; set; }

        public int Order { get; set; }
    }
}
