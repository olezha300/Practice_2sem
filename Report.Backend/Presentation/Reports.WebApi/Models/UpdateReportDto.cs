using AutoMapper;
using Reports.Application.Common.Mappings;
using Reports.Application.Reports.Commands.UpdateReport;

namespace Reports.WebApi.Models;

public class UpdateReportDto : IMapWith<UpdateReportCommand>
{
    public Guid Id { get; set; }
    public string? Product { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateReportDto, UpdateReportCommand>()
            .ForMember(reportCommand => reportCommand.Id,
                opt => opt.MapFrom(report => report.Id))
            .ForMember(reportCommand => reportCommand.Product,
                opt => opt.MapFrom(report => report.Product))
            .ForMember(reportCommand => reportCommand.Count,
                opt => opt.MapFrom(report => report.Count))
            .ForMember(reportCommand => reportCommand.Price,
                opt => opt.MapFrom(report => report.Price));
    }
}