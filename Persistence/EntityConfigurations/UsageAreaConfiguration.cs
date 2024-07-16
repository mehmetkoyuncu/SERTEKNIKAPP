using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UsageAreaConfiguration : IEntityTypeConfiguration<UsageArea>
{
    public void Configure(EntityTypeBuilder<UsageArea> builder)
    {
        builder.ToTable("UsageAreas").HasKey(ua => ua.Id);

        builder.Property(ua => ua.Id).HasColumnName("Id").IsRequired();
        builder.Property(ua => ua.Title).HasColumnName("Title").IsRequired();
        builder.Property(ua => ua.Description).HasColumnName("Description").IsRequired();
        builder.Property(ua => ua.LogoUrl).HasColumnName("LogoUrl").IsRequired();
        builder.Property(ua => ua.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ua => ua.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ua => ua.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ua => !ua.DeletedDate.HasValue);
    }
}