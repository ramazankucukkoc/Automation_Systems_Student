using Core.CrossCuttingConcerns.Types;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Core.Pipelines.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ISecuredRequest
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthorizationBehavior(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<string>? roleClaims = _contextAccessor.HttpContext.User.ClaimRoles();
            if (roleClaims.Count == 0) throw new AuthorizationException("Roller bulunmadı .");

            bool isNotMatchedARoleCliamWithRequestRoles = roleClaims.FirstOrDefault(roleClaim => request.Roles.Any(role => role == roleClaim)).IsNullOrEmpty();
            if (isNotMatchedARoleCliamWithRequestRoles) throw new AuthorizationException("You are not authorized.");

            TResponse response = await next();
            return response;

        }
    }
}
