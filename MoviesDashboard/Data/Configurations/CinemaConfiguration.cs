using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesDashboard.Data.Configurations.Common;
using MoviesDashboard.Models;

namespace MoviesDashboard.Data.Configurations
{
    public class CinemaConfiguration :BaseAuditableEntityConfiguration<int, Cinema>
    {
        public override void Configure(EntityTypeBuilder<Cinema> builder)
        {
            base.Configure(builder);


            builder.Property(C => C.Name)
                .IsRequired()
                .HasColumnType("nvarchar(100)");
        }
    }
}
