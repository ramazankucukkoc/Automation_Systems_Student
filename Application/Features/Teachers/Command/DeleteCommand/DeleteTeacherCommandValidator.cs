using Application.Features.Students.Command.DeleteCommand;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Teachers.Command.DeleteCommand
{
    public class DeleteTeacherCommandValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteTeacherCommandValidator()
        {
            RuleFor(s => s.TCNo).TCNumber();
        }
    }
}