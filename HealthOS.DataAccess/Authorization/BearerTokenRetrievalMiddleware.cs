using Microsoft.AspNetCore.Http;

namespace RealEstate.Data.Authorization
{
    public class BearerTokenRetrievalMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BearerTokenRetrievalMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("AuthToken");

            if (!string.IsNullOrEmpty(token))
            {
                context.Request.Headers.Add("Authorization", "Bearer " + token);
            }

            await _next(context);
        }
    }
}
