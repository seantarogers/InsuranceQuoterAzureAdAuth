namespace InsuranceQuoter.Application.Query.Handlers
{
    using System.Threading.Tasks;
    using InsuranceQuoter.Application.Query.Queries;
    using InsuranceQuoter.Application.Query.Results;
    using InsuranceQuoter.Infrastructure.Constants;
    using InsuranceQuoter.Infrastructure.Functions;
    using InsuranceQuoter.Infrastructure.Message.Dtos;
    using Microsoft.Azure.Cosmos;

    public class GetRiskByUidQueryHandler : IAsyncQueryHandler<GetRiskByUidQuery, RiskByUidResult>
    {
        private readonly ICosmosClientManager cosmosClientManager;

        public GetRiskByUidQueryHandler(ICosmosClientManager cosmosClientManager)
        {
            this.cosmosClientManager = cosmosClientManager;
        }

        public async Task<RiskByUidResult> HandleAsync(GetRiskByUidQuery query)
        {            
            const string sql = "SELECT * FROM c WHERE c.id = @id AND c.type = 'Risk'";

            QueryDefinition queryDefinition = new QueryDefinition(sql)
              .WithParameter("@id", query.Uid);

            var riskDto = await cosmosClientManager.GetItemAsync<RiskDto>(CosmosConstants.CustomerContainerId, CosmosConstants.DatabaseId, queryDefinition);

            return new RiskByUidResult(riskDto);
        }
    }
}