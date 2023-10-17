using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Auths.Command.Register
{
    public class RegiterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegiterCommandValidator()
        {
            RuleFor(x => x.UserForRegisterDto.Password).Password();
            RuleFor(s => s.UserForRegisterDto.Email).NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez")
               .EmailAddress().WithMessage("{PropertyName} formatında mail adresinizi giriniz..");
            RuleFor(s => s.UserForRegisterDto.FirstName).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez").WithName("Ad").FirstLetterMustBeUpperCase();
            RuleFor(s => s.UserForRegisterDto.LastName).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez").WithName("Soyad").FirstLetterMustBeUpperCase();
            RuleFor(s => s.UserForRegisterDto.PhoneNo).PhoneNumber();
            RuleFor(s => s.UserForRegisterDto.TCNo).TCNumber();
            RuleFor(s => s.UserForRegisterDto.BirthDay).GreaterThan(new DateTime(1973, 1, 1)).WithMessage("50 yaşında büyük personeli sistemimize alamayız.")
                .LessThan(new DateTime(2005, 01, 01)).WithMessage("Personelimiz sisteme kaydetmem için en az 18 yaşında olmalıdır");
        }
    }
}
