using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Api.Controllers;
using Api;
using Xunit;

namespace XUnitTestFunds
{
    public class FundsTests : IClassFixture<TestApiFunds<Startup>>
    {
     
        private HttpClient Client;

        public FundsTests(TestApiFunds<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetAllFunds()
        {
            // Arrange
            var request = new
            {
                Url = "http://localhost:63161/get-funds",
                Body = new {
                }
            };

            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();

      //      Act
     //         var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
