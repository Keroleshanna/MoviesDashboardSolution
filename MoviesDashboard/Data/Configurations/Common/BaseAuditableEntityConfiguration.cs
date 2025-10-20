using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesDashboard.Models.Common;

namespace MoviesDashboard.Data.Configurations.Common
{
    public class BaseAuditableEntityConfiguration<TKey, TEntity> : BaseEntityConfiguration<TKey, TEntity>
        where TKey : IEquatable<TKey>
        where TEntity : BaseAuditableEntity<TKey>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);


            builder.Property(A => A.CreatedBy).HasColumnType("nvarchar(100)");
            builder.Property(A => A.LastModifiedBy).HasColumnType("nvarchar(100)");


            builder.Property(A => A.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(A => A.LastModifiedOn).HasColumnType("DATETIME2");
        }
    }
}
