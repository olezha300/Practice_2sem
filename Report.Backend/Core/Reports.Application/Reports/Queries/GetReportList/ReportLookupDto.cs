using AutoMapper;
using Reports.Application.Common.Mappings;
using Reports.Domain;

namespace Reports.Application.Reports.Queries.GetReportList;

public class ReportLookupDto : IMapWith<Report>
{
    public Guid Id { get; set; }
    public string? Product { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Report, ReportLookupDto>()
            .ForMember(reportDto => reportDto.Id,
                opt => opt.MapFrom(report => report.Id))
            .ForMember(reportDto => reportDto.Product,
                opt => opt.MapFrom(report => report.Product));
    }
}