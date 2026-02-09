using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WA_Blog.Models.Entities;

namespace WA_Blog.Models.Mappings
{
    public class PropertyMappings : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Properties");
            builder.ConfigureAuditTrail();
            builder.Property(p => p.Tittle).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Description).HasMaxLength(4000);
            builder.Property(p => p.Price).IsRequired().HasPrecision(18, 2);
            builder.Property(p => p.Address).IsRequired().HasMaxLength(500);
            builder.Property(p => p.City).IsRequired().HasMaxLength(100);
            builder.Property(p => p.State).HasMaxLength(100);
            builder.Property(p => p.ZipCode).HasMaxLength(20);
            builder.Property(p => p.Parking).HasMaxLength(100);
            builder.Property(p => p.PaymentProcess).HasMaxLength(100);
            builder.Property(p => p.VideoUrl).HasMaxLength(500);
            builder.Property(p => p.TotalFlatSpace).HasPrecision(18, 2);
            builder.Property(p => p.Area).HasPrecision(18, 2);

            builder.HasOne(p => p.PropertyType)
                .WithMany(pt => pt.Properties)
                .HasForeignKey(p => p.PropertyTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PropertyImages)
                .WithOne(pi => pi.Property)
                .HasForeignKey(pi => pi.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
