using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Mail).HasColumnName("Mail").IsRequired();
        builder.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
        builder.Property(c => c.PhoneNumber1).HasColumnName("PhoneNumber1").IsRequired();
        builder.Property(c => c.Address).HasColumnName("Address").IsRequired();
        builder.Property(c => c.MapsLat).HasColumnName("MapsLat").IsRequired();
        builder.Property(c => c.MapsLen).HasColumnName("MapsLen").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}