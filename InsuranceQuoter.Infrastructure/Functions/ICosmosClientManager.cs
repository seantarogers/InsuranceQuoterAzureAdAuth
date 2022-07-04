using InsuranceQuoter.Infrastructure.Message.Dtos;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceQuoter.Infrastructure.Functions
{
    public interface ICosmosClientManager
    {
        Task CreateItemAsync<TDto>(TDto dto, string databaseId, string containerId, string partitionKey) where TDto : Dto;
        Task<TDto> GetItemAsync<TDto>(string containerId, string databaseId, QueryDefinition queryDefinition) where TDto : Dto;
        Task<IEnumerable<TDto>> GetItemsAsync<TDto>(string containerId, string databaseId, QueryDefinition queryDefinition) where TDto : Dto;
    }
}