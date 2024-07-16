using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MinistrationConfiguration : IEntityTypeConfiguration<Ministration>
{
    public void Configure(EntityTypeBuilder<Ministration> builder)
    {
        builder.ToTable("Ministrations").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.Title).HasColumnName("Title").IsRequired();
        builder.Property(m => m.Description).HasColumnName("Description").IsRequired();
        builder.Property(m => m.LogoUrl).HasColumnName("LogoUrl").IsRequired();
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}