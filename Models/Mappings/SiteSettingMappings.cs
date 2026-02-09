using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WA_Blog.Models.Entities;

namespace WA_Blog.Models.Mappings
{
    public class SiteSettingMappings : IEntityTypeConfiguration<SiteSetting>
    {
        public void Configure(EntityTypeBuilder<SiteSetting> builder)
        {
            builder.ToTable("SiteSettings");
            builder.ConfigureAuditTrail();
            builder.Property(s => s.PhoneNumber).HasMaxLength(50);
            builder.Property(s => s.Email).HasMaxLength(200);
            builder.Property(s => s.Address).HasMaxLength(500);
            builder.Property(s => s.MapEmbedUrl).HasMaxLength(2000);
            builder.Property(s => s.SiteName).HasMaxLength(200);
        }
    }
}
