using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit.Sdk;

namespace ODataSample.Tests.V7
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<ODataSample.V7.Startup>>
    {
        private readonly HttpClient _client;

        public UnitTest1(WebApplicationFactory<ODataSample.V7.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("/Data(2,'A')")]
        [InlineData("/Data(2, 'A')")]
        [InlineData("/Data(Key1=2, Key2='A')")]
        [InlineData("/Data(Key1=2,Key2='A')")]
        [InlineData("/Data(Key2='A',Key1=2)")]
        public async Task GetWithMultipleKeys(string request)
        {
            var response = await _client.GetAsync(request);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}