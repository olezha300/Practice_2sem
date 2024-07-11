using MediatR;

namespace Reports.Application.Reports.Commands.CreateReport;

public class CreateReportCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string? Product { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public decimal TotalSales { get; set; }
}