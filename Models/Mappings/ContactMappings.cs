using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WA_Blog.Models.Entities;

namespace WA_Blog.Models.Mappings
{
    public class ContactMappings : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.ConfigureAuditTrail();
            builder.Property(c => c.FullName).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Subject).HasMaxLength(300);
            builder.Property(c => c.Message).HasMaxLength(2000);
            builder.Property(c => c.IsRead).IsRequired();
        }
    }
}
