using FluentValidation;

namespace Reports.Application.Reports.Commands.UpdateReport;

public class UpdateReportCommandValidator : AbstractValidator<UpdateReportCommand>
{
    public UpdateReportCommandValidator()
    {
        RuleFor(updateReportCommand =>
            updateReportCommand.UserId).NotEqual(Guid.Empty);
        RuleFor(updateReportCommand =>
            updateReportCommand.Id).NotEqual(Guid.Empty);
        RuleFor(updateReportCommand =>
            updateReportCommand.Product).NotEmpty().MaximumLength(250);
    }
}