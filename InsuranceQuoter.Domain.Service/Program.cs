namespace InsuranceQuoter.Domain.Service
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Threading.Tasks;
    using InsuranceQuoter.Application.Command.Handlers;
    using InsuranceQuoter.Application.Query.Handlers;
    using InsuranceQuoter.Domain.Service.Settings;
    using InsuranceQuoter.Infrastructure.Constants;
    using InsuranceQuoter.Infrastructure.Extensions;
    using InsuranceQuoter.Infrastructure.Functions;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using NServiceBus;
    
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static IEndpointInstance endpointInstance;

        private static void Main()
        {
            ApplicationSettings applicationSettings = DeserializeApplicationSettings();

            try
            {
                EndpointConfiguration endpointConfiguration = BuildEndpointConfiguration(applicationSettings);

                endpointInstance = StartEndpoint(endpointConfiguration);

                Console.WriteLine("Service started successfully");

                RunHost();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Cannot start service. Details: ${exception}");

                return;
            }

            try
            {
                Task.Run(async () => await endpointInstance.Stop()).GetAwaiter().GetResult();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Cannot stop service. Details: ${exception}");
                return;
            }
        }

        private static void RunHost()
        {
            var builder = new HostBuilder();
            var host = builder.Build();

            using (host)
            {
                host.Run();
            }
        }

        private static ApplicationSettings DeserializeApplicationSettings()
        {
            var applicationSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .Get<ApplicationSettings>();
            return applicationSettings;
        }

        private static IEndpointInstance StartEndpoint(EndpointConfiguration configuration)
        {
            return Task.Run(async () => await Endpoint.Start(configuration).ConfigureAwait(false)).GetAwaiter()
                .GetResult();
        }

        private static EndpointConfiguration BuildEndpointConfiguration(ApplicationSettings applicationSettings)
        {
            var endpointConfiguration = new EndpointConfiguration(MessagingEndpointConstants.DomainService);

            endpointConfiguration.SendFailedMessagesTo(MessagingEndpointConstants.DomainService + ".Error");
            endpointConfiguration.EnableInstallers();

            var cosmosConfigurationProvider = new Infrastructure.Providers.CosmosConfigurationProvider(applicationSettings.CosmosEndpoint, applicationSettings.CosmosMasterKey);

            endpointConfiguration.RegisterComponents(
                container =>
                {
                    container.ConfigureComponent<CosmosClientManager>(DependencyLifecycle.SingleInstance);
                    container.ConfigureComponent(() => cosmosConfigurationProvider, DependencyLifecycle.SingleInstance);
                    container.ConfigureComponent<AddRiskCommandHandler>(DependencyLifecycle.InstancePerUnitOfWork);
                    container.ConfigureComponent<AddPolicyCommandHandler>(DependencyLifecycle.InstancePerUnitOfWork);
                    container.ConfigureComponent<GetRiskByUidQueryHandler>(DependencyLifecycle.InstancePerUnitOfWork);
                });

            endpointConfiguration.ConfigureAzureServiceBusTransport(applicationSettings.ServiceBusEndpoint);
            endpointConfiguration.AddUnobtrusiveMessaging();
            endpointConfiguration.UseSerialization<NewtonsoftSerializer>();

            return endpointConfiguration;
        }
    }
}