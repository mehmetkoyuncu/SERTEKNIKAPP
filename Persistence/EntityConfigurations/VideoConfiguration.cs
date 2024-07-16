using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.ToTable("Videos").HasKey(v => v.Id);

        builder.Property(v => v.Id).HasColumnName("Id").IsRequired();
        builder.Property(v => v.VideoUrl).HasColumnName("VideoUrl").IsRequired();
        builder.Property(v => v.VideoType).HasColumnName("VideoType").IsRequired();
        builder.Property(v => v.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(v => v.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(v => v.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(v => !v.DeletedDate.HasValue);
    }
}