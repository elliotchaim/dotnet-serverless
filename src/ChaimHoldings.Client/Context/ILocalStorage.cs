using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ChaimHoldings.Client.Context
{
    public interface ILocalStorage
    {
        Task<string> GetItemAsync(string key);
        Task SetItemAsync(string key, string value);
    }
}