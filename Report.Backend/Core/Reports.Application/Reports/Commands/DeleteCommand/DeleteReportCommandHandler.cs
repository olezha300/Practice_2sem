using MediatR;
using Reports.Application.Common.Exceptions;
using Reports.Application.Interfaces;
using Reports.Domain;

namespace Reports.Application.Reports.Commands.DeleteCommand;

public class DeleteReportCommandHandler 
    : IRequestHandler<DeleteReportCommand>
{
    private readonly IReportsDbContext _dbContext;

    public DeleteReportCommandHandler(IReportsDbContext dbContext) => 
        _dbContext = dbContext;
    
    public async Task Handle(DeleteReportCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Reports
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Report), request.Id);
        }

        _dbContext.Reports.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}