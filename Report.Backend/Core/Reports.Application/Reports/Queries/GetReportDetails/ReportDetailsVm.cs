using AutoMapper;
using Reports.Application.Common.Mappings;
using Reports.Domain;

namespace Reports.Application.Reports.Queries.GetReportDetails;

public class ReportDetailsVm : IMapWith<Report>
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string? Product { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public decimal TotalSales { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Report, ReportDetailsVm>()
            .ForMember(reportVm => reportVm.Id,
                opt => opt.MapFrom(report => report.Id))
            .ForMember(reportVm => reportVm.Date,
                opt => opt.MapFrom(report => report.Date))
            .ForMember(reportVm => reportVm.Product,
                opt => opt.MapFrom(report => report.Product))
            .ForMember(reportVm => reportVm.Count,
                opt => opt.MapFrom(report => report.Count))
            .ForMember(reportVm => reportVm.Price,
                opt => opt.MapFrom(report => report.Price))
            .ForMember(reportVm => reportVm.TotalSales,
                opt => opt.MapFrom(report => report.TotalSales));
    }
}