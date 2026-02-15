using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaAgency.Models.Entities;

namespace VillaAgency.Models.Mappings
{
    public static class BaseEntityMappingExtensions
    {
        public static EntityTypeBuilder<T> ConfigureAuditTrail<T>(this EntityTypeBuilder<T> builder)
            where T : BaseEntity
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.UpdatedDate)
                .IsRequired(false);

            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasQueryFilter(e => !e.IsDeleted);

            return builder;
        }
    }
}
