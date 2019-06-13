using System;
using System.Net.Http;
using ChaimHoldings.Client.Context;
using ChaimHoldings.Sdk;
using IdentityModel.Client;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace ChaimHoldings.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IChaimHoldings>(provider =>
            {
                var localStorage = provider.GetRequiredService<ILocalStorage>();
                var httpClientHandler = new ChaimHoldingsHttpMessageHandler(localStorage);
                var httpClient = new HttpClient(httpClientHandler)
                {
                    BaseAddress = new Uri("http://localhost:7071")
                };
                return new RefitChaimHoldings(httpClient);
            });

            services.AddSingleton<DiscoveryCache>(provider =>
            {
                return new DiscoveryCache("http://localhost:5000");
            });

            services.AddSingleton<ILocalStorage>(provider =>
            {
                var jsRuntime = provider.GetRequiredService<IJSRuntime>();
                return new LocalStorage(jsRuntime);
            });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
