using Microsoft.EntityFrameworkCore;
using Reports.Application.Interfaces;
using Reports.Domain;
using Reports.Persistence.EntityTypeConfigurations;

namespace Reports.Persistence;

public class ReportsDbContext : DbContext, IReportsDbContext
{
    public DbSet<Report> Reports { get; set; }
    
    public ReportsDbContext(DbContextOptions<ReportsDbContext> options)
        : base(options) {  }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ReportConfiguration());
        base.OnModelCreating(builder);
    }
}