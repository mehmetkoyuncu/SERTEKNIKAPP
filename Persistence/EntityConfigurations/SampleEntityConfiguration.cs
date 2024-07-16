using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SampleEntityConfiguration : IEntityTypeConfiguration<SampleEntity>
{
    public void Configure(EntityTypeBuilder<SampleEntity> builder)
    {
        builder.ToTable("SampleEntities").HasKey(se => se.Id);

        builder.Property(se => se.Id).HasColumnName("Id").IsRequired();
        builder.Property(se => se.x).HasColumnName("x").IsRequired();
        builder.Property(se => se.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(se => se.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(se => se.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(se => !se.DeletedDate.HasValue);
    }
}