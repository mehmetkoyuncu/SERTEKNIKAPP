using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.ToTable("Offers").HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.Name).HasColumnName("Name").IsRequired();
        builder.Property(o => o.CompanyName).HasColumnName("CompanyName").IsRequired();
        builder.Property(o => o.Email).HasColumnName("Email").IsRequired();
        builder.Property(o => o.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
        builder.Property(o => o.ProjectName).HasColumnName("ProjectName").IsRequired();
        builder.Property(o => o.Message).HasColumnName("Message").IsRequired();
        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
    }
}