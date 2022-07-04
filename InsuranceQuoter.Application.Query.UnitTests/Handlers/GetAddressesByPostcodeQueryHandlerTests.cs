namespace InsuranceQuoter.Application.Query.Handlers
{
    using AutoFixture;
    using InsuranceQuoter.Application.Query.Queries;
    using InsuranceQuoter.Infrastructure.Constants;
    using InsuranceQuoter.Infrastructure.Functions;
    using InsuranceQuoter.Infrastructure.Message.Dtos;
    using Microsoft.Azure.Cosmos;
    using Moq;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class GetAddressesByPostcodeQueryHandlerTests 
    {
        private readonly Fixture fixture;
        private readonly Mock<ICosmosClientManager> cosmosClientManager;
        private readonly GetAddressesByPostcodeQueryHandler sut;

        public GetAddressesByPostcodeQueryHandlerTests()
        {
            fixture = new Fixture();
            cosmosClientManager = new Mock<ICosmosClientManager>();
            sut = new GetAddressesByPostcodeQueryHandler(cosmosClientManager.Object);
        }

        [Fact]
        public async Task HandleAsync_Should_ReturnAddressByPostcodeResult()
        {
            // Arrange
            var postCode = fixture.Create<string>();

            var query = new GetAddressesByPostCodeQuery(postCode);

            var addressDtos = fixture.CreateMany<AddressDto>(1);

            cosmosClientManager.Setup(a => a.GetItemsAsync<AddressDto>(CosmosConstants.AddressContainerId, CosmosConstants.DatabaseId, 
                It.Is<QueryDefinition>(b => 
                b.QueryText == $"SELECT * FROM c WHERE c.postcode = @postcode" && 
                b.GetQueryParameters().First().Name == "@postcode" && 
                b.GetQueryParameters().First().Value.Equals(query.Postcode)))).ReturnsAsync(addressDtos);

            // Act
            var result = await sut.HandleAsync(query);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Addresses);
            Assert.Equal(result.Addresses.Single(), addressDtos.Single());
        }
    }
}