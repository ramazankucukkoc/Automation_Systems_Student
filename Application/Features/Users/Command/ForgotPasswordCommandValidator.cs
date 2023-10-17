using FluentValidation;

namespace Application.Features.Users.Command
{
    public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordCommandValidator()
        {
            RuleFor(s => s.ForgotPasswordDto.Email).NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez")
             .EmailAddress().WithMessage("{PropertyName} formatında mail adresinizi giriniz..");
        }
    }
}
