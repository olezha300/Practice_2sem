using FluentValidation;

namespace Reports.Application.Reports.Queries.GetReportList;

public class GetReportListQueryValidator : AbstractValidator<GetReportListQuery>
{
    public GetReportListQueryValidator()
    {
        RuleFor(x => x.UserId).NotEqual(Guid.Empty);
    }
}