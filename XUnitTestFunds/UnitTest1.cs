using System;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Api;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace XUnitTestFunds
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    { 
        private readonly HttpClient client;


        public UnitTest1()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            client = server.CreateClient();
        }

        //public UnitTest1()
        //{
        //    var appFactory = new WebApplicationFactory<Startup>();
        //    _client = appFactory.CreateClient();
        //}

        [Fact]
        public async Task Test1()
        {
                var request = "get-funds";

            //    // Act
                var response = await client.GetAsync(request);

            //    // Assert
                response.EnsureSuccessStatusCode();

            //return "Hello";// var response = await _client.GetAsync(requestUri: ApiRoutes.Post.Get);
        }

        [Fact]
        public async Task TestGetAllFunds1()
        {
            // Arrange
            var request = new
            {
                Url = "http://localhost:63161/get-funds",
                Body = new
                {
                }
            };

            var response = await client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
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
