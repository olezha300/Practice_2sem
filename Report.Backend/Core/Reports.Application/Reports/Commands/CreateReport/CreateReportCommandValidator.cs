using FluentValidation;

namespace Reports.Application.Reports.Commands.CreateReport;

public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
{
    public CreateReportCommandValidator()
    {
        RuleFor(createReportCommand =>
            createReportCommand.Product).NotEmpty().MaximumLength(250);
        RuleFor(createReportCommand =>
            createReportCommand.UserId).NotEqual(Guid.Empty);
    }
}