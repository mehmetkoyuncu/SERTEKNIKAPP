using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ServiceSummaryConfiguration : IEntityTypeConfiguration<ServiceSummary>
{
    public void Configure(EntityTypeBuilder<ServiceSummary> builder)
    {
        builder.ToTable("ServiceSummaries").HasKey(ss => ss.Id);

        builder.Property(ss => ss.Id).HasColumnName("Id").IsRequired();
        builder.Property(ss => ss.Title).HasColumnName("Title").IsRequired();
        builder.Property(ss => ss.Description).HasColumnName("Description").IsRequired();
        builder.Property(ss => ss.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ss => ss.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ss => ss.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ss => !ss.DeletedDate.HasValue);
    }
}