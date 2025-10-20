using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesDashboard.Models.Common;

namespace MoviesDashboard.Data.Configurations.Common
{
    public class BaseEntityConfiguration<TKey, TEntity> : IEntityTypeConfiguration<TEntity>
        where TKey : IEquatable<TKey>
        where TEntity : BaseEntity<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.Id).UseIdentityColumn(5, 5);
        }
    }
}
