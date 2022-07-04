using InsuranceQuoter.Application.Query.Handlers;
using InsuranceQuoter.Application.Query.Queries;
using InsuranceQuoter.Application.Query.Results;
using InsuranceQuoter.Infrastructure.Functions;
using InsuranceQuoter.Infrastructure.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;

namespace InsuranceQuoter.Presentation.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();

            services.AddSingleton<ICosmosClientManager, CosmosClientManager>();

            var cosmosConfigurationProvider = new CosmosConfigurationProvider(Program.ApplicationSettings.CosmosEndpoint, Program.ApplicationSettings.CosmosMasterKey);
            services.AddSingleton(cosmosConfigurationProvider);

            services.AddScoped<IAsyncQueryHandler<GetAddressesByPostCodeQuery, AddressesByPostcodeResult>, GetAddressesByPostcodeQueryHandler>();
            services.AddScoped<IAsyncQueryHandler<GetCarByRegistrationNumberQuery, CarByRegistrationNumberResult>, GetCarByRegistrationNumberQueryHandler>();
            services.AddScoped<IAsyncQueryHandler<GetPoliciesByUserNameQuery, PoliciesByUserNameResult>, GetPoliciesByUserNameQueryHandler>();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration, configSectionName: "AzureAd");
            
            var requireAuthenticatedUserPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            services.AddControllers(c => c.Filters.Add(new AuthorizeFilter(requireAuthenticatedUserPolicy)));

            services.AddCors(options => { options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Open");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapHealthChecks("/health");
                    endpoints.MapControllers();
                });
        }
    }
}