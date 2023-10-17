using Application.Features.Auths.Rules;
using Application.Features.Courses.Rules;
using Application.Features.OperationClaims.Rules;
using Application.Features.StudentCourses.Rules;
using Application.Features.Students.Rules;
using Application.Features.Users.Rules;
using Application.Services.Auths;
using Application.Services.Courses;
using Application.Services.OperationClaims;
using Application.Services.Students;
using Application.Services.Users;
using Core.Mailings;
using FluentValidation;
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
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<StudentBusinessRules>();
            services.AddScoped<StudentCourseBusinessRules>();
            services.AddScoped<CourseBusinessRules>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IOperationClaimService, OperationCliamManager>();

            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<IStudentService, StudentManager>();

            services.AddScoped<IMailService, MailKitMailService>();


            return services;
        }
    }
}
