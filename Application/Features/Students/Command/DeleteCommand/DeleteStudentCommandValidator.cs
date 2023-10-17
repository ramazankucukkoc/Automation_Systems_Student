using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Students.Command.DeleteCommand
{
    public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentCommandValidator()
        {
            RuleFor(s => s.TCNo).TCNumber();
        }
    }
}
