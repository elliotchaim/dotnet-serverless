using ChaimHoldings.Client.Context;
using Microsoft.AspNetCore.Blazor.Http;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ChaimHoldings.Client
{
    public class ChaimHoldingsHttpMessageHandler : WebAssemblyHttpMessageHandler
    {
        private readonly ILocalStorage _localStorage;

        public ChaimHoldingsHttpMessageHandler(ILocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await _localStorage.GetItemAsync("access_token");
            request.SetBearerToken(accessToken);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
