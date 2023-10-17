using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Teachers.Command.CreateCommand
{
    public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
    {
        public CreateTeacherCommandValidator()
        {
            RuleFor(s => s.Email).NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez")
               .EmailAddress().WithMessage("{PropertyName} formatında mail adresinizi giriniz..");

            RuleFor(s => s.FirstName).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez").WithName("Ad").FirstLetterMustBeUpperCase();
            RuleFor(s => s.LastName).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez").WithName("Soyad").FirstLetterMustBeUpperCase();
            RuleFor(s => s.PhoneNo).PhoneNumber();
            RuleFor(s => s.TCNo).TCNumber();
            RuleFor(s => s.BirthDay).GreaterThan(new DateTime(1973, 1, 1)).WithMessage("50 yaşında büyük personeli sistemimize alamayız.")
                .LessThan(new DateTime(2005, 01, 01)).WithMessage("Personelimiz sisteme kaydetmem için en az 18 yaşında olmalıdır");
        }
    }
}
