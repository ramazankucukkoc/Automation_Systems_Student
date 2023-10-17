using FluentValidation;

namespace Application.Features.StudentCourses.Command.CreateCommand
{
    public class CreateStudentCourseCommandValidator : AbstractValidator<CreateStudentCourseCommand>
    {
        public CreateStudentCourseCommandValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty().WithMessage("{PropertyName} Alan Boş geçilmez")
                .GreaterThan(0).WithMessage("{PropertyName} Bu alan sıfırdan büyük olmalı");
            RuleFor(x => x.StudentId).NotEmpty().WithMessage("Alan Boş geçilmez")
               .GreaterThan(0).WithMessage("Bu alan sıfırdan büyük olmalı");
            RuleFor(x => x.Note1).GreaterThan(0).WithName("Sınav -1").WithMessage("{PropertyName} Sıfır'dan büyük olmalı")
                .LessThan(101).WithMessage("{PropertyName} alanı 100'den büyük olamaz");
            RuleFor(x => x.Note2).GreaterThan(0).WithName("Sınav -2").WithMessage("{PropertyName} Sıfır'dan büyük olmalı")
              .LessThan(101).WithMessage("{PropertyName} alanı 100'den büyük olamaz");

        }
    }
}
