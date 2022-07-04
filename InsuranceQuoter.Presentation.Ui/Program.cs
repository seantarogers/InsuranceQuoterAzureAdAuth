namespace InsuranceQuoter.Presentation.Ui
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Fluxor;
    using Exceptions;
    using InsuranceQuoter.Presentation.Ui.Functions;
    using InsuranceQuoter.Presentation.Ui.Providers;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault();

            string presentationApiEndpoint = GetPresentationApiEndpoint(builder);
            string identityProviderEndpoint = Get(builder);
            string hubEndpoint = GetHubEndpoint(builder);
            string presentationUiEndpoint = GetPresentationUiEndpoint(builder);

            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<SignalRConnectionManager>();
            builder.Services.AddScoped<TimerManager>();
            builder.Services.AddSingleton(new EndpointProvider(presentationApiEndpoint, hubEndpoint));
            builder.Services.AddTransient<AccessTokenExtractor>();

            const string apiScope = "api://b04b2626-5445-4c36-a8b7-ebb6f43ddda8/read_write";

            builder.Services.AddMsalAuthentication(
                options =>
                {
                    options.ProviderOptions.Authentication.ClientId = "66c049a6-adc4-464e-b769-f736d311fb79";
                    options.ProviderOptions.Authentication.Authority = "https://login.microsoftonline.com/e85feadf-11e7-47bb-a160-43b98dcc96f1";
                    options.ProviderOptions.Authentication.ValidateAuthority = true;
                    options.ProviderOptions.DefaultAccessTokenScopes.Add(apiScope);
                    options.ProviderOptions.DefaultAccessTokenScopes.Add("openid");
                    options.ProviderOptions.DefaultAccessTokenScopes.Add("profile");
                    options.ProviderOptions.DefaultAccessTokenScopes.Add("email");
                    options.ProviderOptions.DefaultAccessTokenScopes.Add("User.Read");
                });
            
            builder.Services.AddFluxor(
                config => config
                    .ScanAssemblies(typeof(Program).Assembly)
                    //.UsePersist() //TODO wire up Session Storage
                    .UseReduxDevTools());

            await builder.Build().RunAsync();
        }

        private static string GetPresentationUiEndpoint(WebAssemblyHostBuilder builder)
        {
            string presentationUiEndpoint = builder.Configuration["PresentationUiEndpoint"];
            if (string.IsNullOrWhiteSpace(presentationUiEndpoint))
            {
                throw new AppSettingsItemNotFoundException();
            }

            return presentationUiEndpoint;
        }

        private static string GetHubEndpoint(WebAssemblyHostBuilder builder)
        {
            string hubEndpoint = builder.Configuration["HubEndpoint"];
            if (string.IsNullOrWhiteSpace(hubEndpoint))
            {
                throw new AppSettingsItemNotFoundException();
            }

            return hubEndpoint;
        }

        private static string Get(WebAssemblyHostBuilder builder)
        {
            string identityProviderEndpoint = builder.Configuration["IdentityProviderEndpoint"];
            if (string.IsNullOrWhiteSpace(identityProviderEndpoint))
            {
                throw new AppSettingsItemNotFoundException();
            }

            return identityProviderEndpoint;
        }

        private static string GetPresentationApiEndpoint(WebAssemblyHostBuilder builder)
        {
            string presentationApiEndpoint = builder.Configuration["PresentationApiEndpoint"];
            if (string.IsNullOrWhiteSpace(presentationApiEndpoint))
            {
                throw new AppSettingsItemNotFoundException();
            }

            return presentationApiEndpoint;
        }
    }
}