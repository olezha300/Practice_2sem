using MediatR;
using Reports.Application.Interfaces;
using Reports.Domain;

namespace Reports.Application.Reports.Commands.CreateReport;

public class CreateReportCommandHandler 
    : IRequestHandler<CreateReportCommand, Guid>
{
    private readonly IReportsDbContext _dbContext;

    public CreateReportCommandHandler(IReportsDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Guid> Handle(CreateReportCommand request,
        CancellationToken cancellationToken)
    {
        var report = new Report
        {
            UserId = request.UserId,
            Product = request.Product,
            Count = request.Count,
            Price = request.Price,
            TotalSales = request.TotalSales,
            Id = Guid.NewGuid(),
            Date = DateTime.Now
        };

        await _dbContext.Reports.AddAsync(report, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return report.Id;
    }
}