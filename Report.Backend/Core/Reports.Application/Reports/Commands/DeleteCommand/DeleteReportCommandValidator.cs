using FluentValidation;

namespace Reports.Application.Reports.Commands.DeleteCommand;

public class DeleteReportCommandValidator : AbstractValidator<DeleteReportCommand>
{
    public DeleteReportCommandValidator()
    {
        RuleFor(deleteReportCommand =>
            deleteReportCommand.UserId).NotEqual(Guid.Empty);
        RuleFor(deleteReportCommand =>
            deleteReportCommand.Id).NotEqual(Guid.Empty);
    }
}