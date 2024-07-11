using MediatR;

namespace Reports.Application.Reports.Commands.UpdateReport;

public class UpdateReportCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string? Product { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public decimal TotalSales { get; set; }
}