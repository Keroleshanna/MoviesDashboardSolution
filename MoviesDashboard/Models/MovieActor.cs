using Microsoft.EntityFrameworkCore;
using MoviesDashboard.Models.Common;

namespace MoviesDashboard.Models
{
    [PrimaryKey(nameof(ActorId),nameof(MovieId))]
    public class MovieActor
    {
        public int ActorId { get; set; }
        public Actor Actor { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}
