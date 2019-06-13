using System.Collections.Generic;
using System.Threading.Tasks;
using ChaimHoldings.Sdk.Property.List;
using Refit;

namespace ChaimHoldings.Sdk.Property
{
    public interface IProperty
    {
        [Get("/properties.list")]
        Task<IEnumerable<ListPropertyProjection>> ListAsync();
    }
}