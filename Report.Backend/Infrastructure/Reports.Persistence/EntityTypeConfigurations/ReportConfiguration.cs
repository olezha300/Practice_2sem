using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reports.Domain;

namespace Reports.Persistence.EntityTypeConfigurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.HasKey(report => report.Id);
        builder.HasIndex(report => report.Id).IsUnique();
        builder.Property(report => report.Product).HasMaxLength(250);
    }
}