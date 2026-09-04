using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace AIAgent.Handlers
{
    public class JwtAuthorizationHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            var authorizationHeader =
                _httpContextAccessor
                    .HttpContext?
                    .Request
                    .Headers["Authorization"]
                    .FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(authorizationHeader))
            {
                request.Headers.Authorization =
                    AuthenticationHeaderValue.Parse(
                        authorizationHeader);
            }

            return await base.SendAsync(
                request,
                cancellationToken);
        }
    }
}
