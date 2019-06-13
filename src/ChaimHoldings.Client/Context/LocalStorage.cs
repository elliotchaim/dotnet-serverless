using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ChaimHoldings.Client.Context
{
    public class LocalStorage : ILocalStorage
    {
        private readonly IJSRuntime _jsRuntime;

        public LocalStorage(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public Task<string> GetItemAsync(string key)
        {
            return _jsRuntime.InvokeAsync<string>("window.localStorageHelper.getItem", key);
        }

        public Task SetItemAsync(string key, string value)
        {
            return _jsRuntime.InvokeAsync<object>("window.localStorageHelper.setItem", key, value);
        }
    }
}