using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Students.Command.CreateCommand
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(s => s.Email).NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez")
                .EmailAddress().WithMessage("{PropertyName} formatında mail adresinizi giriniz..");

            RuleFor(s => s.FirstName).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez").WithName("Ad").FirstLetterMustBeUpperCase();
            RuleFor(s => s.LastName).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez").WithName("Soyad").FirstLetterMustBeUpperCase();
            RuleFor(s => s.PhoneNo).PhoneNumber();
            RuleFor(s => s.TCNo).TCNumber();
            RuleFor(s => s.BirthDay).GreaterThan(new DateTime(2010, 1, 1)).WithMessage("13 yaşında büyükleri sistemimize alamayız.")
                .LessThan(new DateTime(2017, 01, 01)).WithMessage("Ögrencimizi sisteme kaydetmem için en az 6 yaşında olmalıdır Dogum Tarihi alanına" +
                " bakabilirsiniz.");

        }
    }
}
