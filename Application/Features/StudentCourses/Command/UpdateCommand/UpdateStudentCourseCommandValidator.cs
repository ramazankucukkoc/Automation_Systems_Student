using FluentValidation;

namespace Application.Features.StudentCourses.Command.UpdateCommand
{
    public class UpdateStudentCourseCommandValidator : AbstractValidator<UpdateStudentCourseCommand>
    {
        public UpdateStudentCourseCommandValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty().WithMessage("{PropertyName} Alan Boş geçilmez")
               .GreaterThan(0).WithMessage("Bu alan sıfırdan büyük olmalı");
            RuleFor(x => x.StudentId).NotEmpty().WithMessage("{PropertyName} Alan Boş geçilmez")
               .GreaterThan(0).WithMessage("Bu alan sıfırdan büyük olmalı");
            RuleFor(x => x.Note1).GreaterThan(0).WithName("Sınav -1").WithMessage("{PropertyName} Sıfır'dan büyük olmalı")
                .LessThan(101).WithMessage("{PropertyName} alanı 100'den büyük olamaz");
            RuleFor(x => x.Note2).GreaterThan(0).WithName("Sınav -2").WithMessage("{PropertyName} Sıfır'dan büyük olmalı")
              .LessThan(101).WithMessage("{PropertyName} alanı 100'den büyük olamaz");

        }

    }
}
