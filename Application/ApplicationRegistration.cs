using Application.Features.Auths.Rules;
using Application.Features.OperationClaims.Rules;
using Application.Features.Users.Rules;
using Application.Services.OperationClaims;
using Application.Services.Users;
using Core.Mailings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationRegisteration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<UserBusinessRules>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IOperationClaimService, OperationCliamManager>();

            services.AddScoped<IMailService, MailKitMailService>();


            return services;
        }
    }
}
