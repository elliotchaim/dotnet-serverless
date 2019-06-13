using ChaimHoldings.Client.Context;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ChaimHoldings.Client.Pages
{
    public class AuthorizeComponent : ComponentBase
    {
        protected override async Task OnInitAsync()
        {
            var accessToken = await LocalStorage.GetItemAsync("access_token");
            // todo: check token expiry
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                // todo: pass current url for final redirect
                UriHelper.NavigateTo("/signin");
            }
        }

        [Inject]
        private ILocalStorage LocalStorage { get; set; }

        [Inject]
        private IUriHelper UriHelper { get; set; }
    }
}
