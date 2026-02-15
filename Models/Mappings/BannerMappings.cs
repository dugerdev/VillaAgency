using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaAgency.Models.Entities;

namespace VillaAgency.Models.Mappings
{
    public class BannerMappings : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.ToTable("Banners");
            builder.ConfigureAuditTrail();
            builder.Property(b => b.Tittle).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Category).HasMaxLength(200);
            builder.Property(b => b.Description).HasMaxLength(1000);
            builder.Property(b => b.ImageUrl).HasMaxLength(500);
            builder.Property(b => b.LinkedinUrl).HasMaxLength(500);
            builder.Property(b => b.DisplayOrder).IsRequired();
        }
    }
}
