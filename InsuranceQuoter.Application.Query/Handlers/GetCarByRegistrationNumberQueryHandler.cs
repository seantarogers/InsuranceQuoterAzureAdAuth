namespace InsuranceQuoter.Application.Query.Handlers
{
    using System.Threading.Tasks;
    using InsuranceQuoter.Application.Query.Queries;
    using InsuranceQuoter.Application.Query.Results;
    using InsuranceQuoter.Infrastructure.Constants;
    using InsuranceQuoter.Infrastructure.Functions;
    using InsuranceQuoter.Infrastructure.Message.Dtos;
    using Microsoft.Azure.Cosmos;

    public class GetCarByRegistrationNumberQueryHandler : IAsyncQueryHandler<GetCarByRegistrationNumberQuery, CarByRegistrationNumberResult>
    {
        private readonly ICosmosClientManager cosmosClientManager;

        public GetCarByRegistrationNumberQueryHandler(ICosmosClientManager cosmosClientManager)
        {
            this.cosmosClientManager = cosmosClientManager;
        }

        public async Task<CarByRegistrationNumberResult> HandleAsync(GetCarByRegistrationNumberQuery query)
        {
            const string sql = "SELECT * FROM c WHERE c.registrationNumber = @registrationNumber";

            QueryDefinition queryDefinition = new QueryDefinition(sql)
              .WithParameter("@registrationNumber", query.RegistrationNumber);

            var carDto = await cosmosClientManager.GetItemAsync<CarDto>(CosmosConstants.CarContainerId, CosmosConstants.DatabaseId, queryDefinition);

            return new CarByRegistrationNumberResult(carDto);
        }
    }
}