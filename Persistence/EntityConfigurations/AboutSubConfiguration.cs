using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AboutSubConfiguration : IEntityTypeConfiguration<AboutSub>
{
    public void Configure(EntityTypeBuilder<AboutSub> builder)
    {
        builder.ToTable("AboutSubs").HasKey(ass => ass.Id);

        builder.Property(ass => ass.Id).HasColumnName("Id").IsRequired();
        builder.Property(ass => ass.Title).HasColumnName("Title").IsRequired();
        builder.Property(ass => ass.Description).HasColumnName("Description").IsRequired();
        builder.Property(ass => ass.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ass => ass.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ass => ass.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ass => !ass.DeletedDate.HasValue);
    }
}