using Core.Pipelines.Validation;
using Core.Security.Jwt;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Security.Extensions
{
    public static class SecurityServiceRegistration
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, JwtHelper>();
            //services.AddScoped<IEmailAuthenticatorHelper, EmailAuthenticatorHelper>();
            //services.AddScoped<IOtpAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();
            //services.AddScoped<IMicrosoftAuthAdapter, MicrosoftAuthAdapter>();
            //services.AddScoped<IGoogleAuthAdapter, GoogleAuthAdapter>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }

    }
}