using Microsoft.EntityFrameworkCore;
using Reports.Domain;

namespace Reports.Application.Interfaces;

public interface IReportsDbContext
{
    DbSet<Report> Reports { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}