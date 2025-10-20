using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesDashboard.Data.Configurations.Common;
using MoviesDashboard.Models;

namespace MoviesDashboard.Data.Configurations
{
    public class MovieConfiguration : BaseAuditableEntityConfiguration<int, Movie>
    {
        public override void Configure(EntityTypeBuilder<Movie> builder)
        {
            base.Configure(builder);

            builder.Property(M => M.Name)
                .IsRequired()
                .HasColumnType("nvarchar(200)");

            builder.Property(M => M.Price)
                .HasColumnType("decimal(7,2)");
        }
    }
}
