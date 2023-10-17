using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Students.Command.UpdateCommand
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommandStudent>
    {
        public UpdateCommandValidator()
        {
            RuleFor(s => s.Email).NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez")
               .EmailAddress().WithMessage("{PropertyName} formatında mail adresinizi giriniz..");

            RuleFor(s => s.FirstName).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez");
            RuleFor(s => s.LastName).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez");
            RuleFor(s => s.PhoneNo).PhoneNumber();
            RuleFor(s => s.TCNo).TCNumber();
            RuleFor(s => s.BirthDay).GreaterThan(new DateTime(2010, 1, 1)).WithMessage("13 yaşında büyükleri sistemimize alamayız.")
                .LessThan(DateTime.Now);

        }
    }
}
