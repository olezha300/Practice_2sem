using MediatR;
using Microsoft.EntityFrameworkCore;
using Reports.Application.Common.Exceptions;
using Reports.Application.Interfaces;
using Reports.Domain;

namespace Reports.Application.Reports.Commands.UpdateReport;

public class UpdateReportCommandHandler 
    : IRequestHandler<UpdateReportCommand>
{
    private readonly IReportsDbContext _dbContext;

    public UpdateReportCommandHandler(IReportsDbContext dbContext) => 
        _dbContext = dbContext;
    
    public async Task Handle(UpdateReportCommand request,
        CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.Reports.FirstOrDefaultAsync(report =>
                report.Id == request.Id, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Report), request.Id);
        }

        entity.Product = request.Product;
        entity.Count = request.Count;
        entity.Price = request.Price;
        entity.TotalSales = request.TotalSales;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}