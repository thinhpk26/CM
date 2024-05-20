using Repo.Entities;
using Business;
using Controller.Response;
using Repo.Context;
using System.Text.Json;
using Microsoft.Net.Http.Headers;

namespace Controller.Middleware
{
    public class RequestInforMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestInforMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ICMHttpContext context)
        {
            context.SetHttpContext(httpContext);
            var user = httpContext.User;
            var error = new List<string>();
            if(!user.Identity.IsAuthenticated)
            {
                error.Add("Author");
                throw new BusinessException(error);
            }
            var userClaim = user.Claims.FirstOrDefault(c => c.Type == "User");
            var companyClaim = user.Claims.FirstOrDefault(c => c.Type == "Company");
            if (userClaim == null || companyClaim == null)
            {
                error.Add("Author");
                throw new BusinessException(error);
            }
            try
            {
                context.SetUser(JsonSerializer.Deserialize<UserContext>(userClaim.Value));
                context.SetCompany(JsonSerializer.Deserialize<CompanyContext>(companyClaim.Value));
            } catch
            {
                error.Add("Error_token");
                throw new BusinessException(error);
            }
            await _next.Invoke(httpContext);
        }
    }
}
