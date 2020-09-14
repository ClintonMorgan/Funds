using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Controllers;
using Api.DataFiles;
using Api;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace XUnitTestFunds
{
    public class NewTestFunds : IClassFixture<WebApplicationFactory<Startup>>
    {
       // private readonly HttpClient _client;

        //public NewTestFunds()
        //{
        //    var server = new TestServer(new WebHostBuilder()
        //        .UseEnvironment("Development")
        //        .UseStartup<Startup>());
        //    _client = server.CreateClient();
        //}


        public readonly HttpClient _httpClient;

        //public UnitTest1()
        //{
        //    var appFactory = new WebApplicationFactory<Startup>();
        //    _httpClient = appFactory.CreateDefaultClient();
        //}
        public NewTestFunds(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();

        }



        [Fact]
        public async Task HealthCheck_ReturnsOk()
        {
            var response = await _httpClient.GetAsync("/get-funds");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        //[Theory]
        //    [InlineData("GET")]
        ////[Fact]
        //public async Task GetFunds(string method)
        //{
        //    // Arrange
        //    var request = new HttpRequestMessage(new HttpMethod(method), "get-funds");

        //    // Act
        //    var response = await _client.SendAsync(request);

        //    // Assert
        //    response.EnsureSuccessStatusCode();
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //}


        //[Theory]
        //[InlineData("GET", "EA")]
        //public async Task GetFund(string method, string id)
        //{
        //    // Arrange
        //    var request = new HttpRequestMessage(new HttpMethod(method), "get-funds/{id}");

        //    // Act
        //    var response = await _client.SendAsync(request);

        //    // Assert
        //    response.EnsureSuccessStatusCode();
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //}
    }
}
