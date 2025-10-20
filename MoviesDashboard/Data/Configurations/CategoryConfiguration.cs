using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesDashboard.Data.Configurations.Common;
using MoviesDashboard.Models;

namespace MoviesDashboard.Data.Configurations
{
    public class CategoryConfiguration : BaseAuditableEntityConfiguration<int, Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(C => C.Name)
                .IsRequired()
                .HasColumnType("nvarchar(100)");
        }
    }
}
