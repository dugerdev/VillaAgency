using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaAgency.Models.Entities;

namespace VillaAgency.Models.Mappings
{
    public class FAQMappings : IEntityTypeConfiguration<FAQ>
    {
        public void Configure(EntityTypeBuilder<FAQ> builder)
        {
            builder.ToTable("FAQs");
            builder.ConfigureAuditTrail();
            builder.Property(f => f.Question).IsRequired().HasMaxLength(500);
            builder.Property(f => f.Answer).IsRequired().HasMaxLength(2000);
            builder.Property(f => f.DisplayOrder).IsRequired();
        }
    }
}
