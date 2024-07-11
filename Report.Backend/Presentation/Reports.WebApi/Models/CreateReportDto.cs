using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Reports.Application.Common.Mappings;
using Reports.Application.Reports.Commands.CreateReport;

namespace Reports.WebApi.Models;

public class CreateReportDto : IMapWith<CreateReportCommand>
{
    [Required]
    public string? Product { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateReportDto, CreateReportCommand>()
            .ForMember(reportCommand => reportCommand.Product,
                opt => opt.MapFrom(report => report.Product))
            .ForMember(reportCommand => reportCommand.Count,
                opt => opt.MapFrom(report => report.Count))
            .ForMember(reportCommand => reportCommand.Price,
                opt => opt.MapFrom(report => report.Price));
    }
}