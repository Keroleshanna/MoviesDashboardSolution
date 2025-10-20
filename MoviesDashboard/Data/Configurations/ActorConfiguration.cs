using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesDashboard.Data.Configurations.Common;
using MoviesDashboard.Models;

namespace MoviesDashboard.Data.Configurations
{
    public class ActorConfiguration : BaseAuditableEntityConfiguration<int, Actor>
    {
        public override void Configure(EntityTypeBuilder<Actor> builder)
        {
            base.Configure(builder);

            builder.Property(A => A.Name)
                .HasColumnType("nvarchar(100)")
                .IsRequired();
        }
    }
}
