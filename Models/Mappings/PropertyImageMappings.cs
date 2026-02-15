using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaAgency.Models.Entities;

namespace VillaAgency.Models.Mappings
{
    public class PropertyImageMappings : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToTable("PropertyImages");
            builder.ConfigureAuditTrail();
            builder.Property(p => p.ImageUrl).IsRequired().HasMaxLength(500);
            builder.Property(p => p.PropertyId).IsRequired();
            builder.Property(p => p.IsMain).IsRequired();
            builder.Property(p => p.DisplayOrder).IsRequired();
        }
    }
}
