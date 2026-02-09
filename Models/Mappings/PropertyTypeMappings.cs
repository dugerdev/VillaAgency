using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WA_Blog.Models.Entities;

namespace WA_Blog.Models.Mappings
{
    public class PropertyTypeMappings : IEntityTypeConfiguration<PropertyType>
    {
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            builder.ToTable("PropertyTypes");
            builder.ConfigureAuditTrail();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
        }
    }
}
