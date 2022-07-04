namespace InsuranceQuoter.Application.Query.Handlers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using InsuranceQuoter.Application.Query.Queries;
    using InsuranceQuoter.Application.Query.Results;
    using InsuranceQuoter.Infrastructure.Constants;
    using InsuranceQuoter.Infrastructure.Functions;
    using InsuranceQuoter.Infrastructure.Message.Dtos;
    using Microsoft.Azure.Cosmos;

    public class GetAddressesByPostcodeQueryHandler : IAsyncQueryHandler<GetAddressesByPostCodeQuery, AddressesByPostcodeResult>
    {
        private readonly ICosmosClientManager cosmosClientManager;

        public GetAddressesByPostcodeQueryHandler(ICosmosClientManager cosmosClientManager)
        {
            this.cosmosClientManager = cosmosClientManager;
        }

        public async Task<AddressesByPostcodeResult> HandleAsync(GetAddressesByPostCodeQuery query)
        {
            const string sql = "SELECT * FROM c WHERE c.postcode = @postcode";

            QueryDefinition queryDefinition = new QueryDefinition(sql)
              .WithParameter("@postcode", query.Postcode);

            IEnumerable<AddressDto> addressDtos = await cosmosClientManager.GetItemsAsync<AddressDto>(CosmosConstants.AddressContainerId, CosmosConstants.DatabaseId, queryDefinition);

            return new AddressesByPostcodeResult(addressDtos);
        }
    }
}