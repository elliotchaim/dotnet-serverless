using System.Net.Http;
using ChaimHoldings.Sdk.Property;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;

namespace ChaimHoldings.Sdk
{
    public class RefitChaimHoldings : IChaimHoldings
    {
        public RefitChaimHoldings(HttpClient httpClient)
        {
            Property = RestService.For<IProperty>(httpClient, RefitSettings);
        }

        public IProperty Property { get; }

        private static readonly RefitSettings RefitSettings = new RefitSettings
        {
            ContentSerializer = new JsonContentSerializer
            (
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters =
                    {
                        new StringEnumConverter()
                    }
                }
            )
        };
    }
}
