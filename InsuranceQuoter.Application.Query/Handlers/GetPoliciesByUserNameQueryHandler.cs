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

    public class GetPoliciesByUserNameQueryHandler : IAsyncQueryHandler<GetPoliciesByUserNameQuery, PoliciesByUserNameResult>
    {
        private readonly ICosmosClientManager cosmosClientManager;

        public GetPoliciesByUserNameQueryHandler(ICosmosClientManager cosmosClientManager)
        {
            this.cosmosClientManager = cosmosClientManager;
        }

        public async Task<PoliciesByUserNameResult> HandleAsync(GetPoliciesByUserNameQuery query)
        {
            const string sql = "SELECT * FROM c WHERE c.email = @email AND c.type = 'Policy'";

            QueryDefinition queryDefinition = new QueryDefinition(sql)
              .WithParameter("@email", query.UserName);

            IEnumerable<PolicyDto> policyDtos = await cosmosClientManager.GetItemsAsync<PolicyDto>(CosmosConstants.CustomerContainerId, CosmosConstants.DatabaseId, queryDefinition);

            return new PoliciesByUserNameResult(policyDtos);
        }
    }
}