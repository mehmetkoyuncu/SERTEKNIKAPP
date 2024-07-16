using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CompanyInfoConfiguration : IEntityTypeConfiguration<CompanyInfo>
{
    public void Configure(EntityTypeBuilder<CompanyInfo> builder)
    {
        builder.ToTable("CompanyInfoes").HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id).HasColumnName("Id").IsRequired();
        builder.Property(ci => ci.LogoUrl).HasColumnName("LogoUrl").IsRequired();
        builder.Property(ci => ci.Mail).HasColumnName("Mail").IsRequired();
        builder.Property(ci => ci.Phone1).HasColumnName("Phone1").IsRequired();
        builder.Property(ci => ci.Phone2).HasColumnName("Phone2").IsRequired();
        builder.Property(ci => ci.Address).HasColumnName("Address").IsRequired();
        builder.Property(ci => ci.GoogleMapAddress).HasColumnName("GoogleMapAddress").IsRequired();
        builder.Property(ci => ci.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ci => ci.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ci => ci.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ci => !ci.DeletedDate.HasValue);
    }
}