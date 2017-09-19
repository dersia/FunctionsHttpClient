using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionsHttpClient
{
    public class AuthPassthroughHandler : DelegatingHandler
    {
        private AuthenticationHeaderValue _authHeader;
        private bool _overrideAuth = false;

        public AuthPassthroughHandler(AuthenticationHeaderValue authHeader, bool overrideAuth = false, HttpMessageHandler innerHandler = null) : base (innerHandler)
        {
            _authHeader = authHeader;
            _overrideAuth = overrideAuth;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_authHeader != null && (request.Headers.Authorization != null || _overrideAuth))
            {
                request.Headers.Authorization = _authHeader;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
