namespace Reports.Domain;

public class Report
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string? Product { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public decimal TotalSales { get; set; }
}