using JurosApp.Calculo.Application.Services;
using JurosApp.Calculo.Application.Tests.Utils;
using JurosApp.SharedKernel.Commons;
using JurosApp.SharedKernel.Microservices.Options;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace JurosApp.Calculo.Application.Tests.Services
{
    public class ExternalTaxasProviderServiceTest
    {
        public class GetTaxaJuros
        {
            [Fact]
            public async void should_fail_when_no_microservice_location_was_configured()
            {
                var options = new MockMicroserviceOptions();
                var httpClient = new Mock<HttpClient>();
                var service = new ExternalTaxasProviderService(options.Object, httpClient.Object);

                var result = await service.GetTaxaJuros();

                Assert.False(result.Succeeded);
            }

            [Theory]
            [InlineData(HttpStatusCode.BadRequest)]
            [InlineData(HttpStatusCode.NotFound)]
            [InlineData(HttpStatusCode.InternalServerError)]
            public async void should_fail_when_http_request_fails(HttpStatusCode failStatusCode)
            {
                var options = new MockMicroserviceOptions(defaultLocations: true);
                var httpClient = MockHttpClientFactory.Create(failStatusCode, string.Empty);

                var service = new ExternalTaxasProviderService(options.Object, httpClient);

                var result = await service.GetTaxaJuros();

                Assert.False(result.Succeeded);
            }

            [Fact]
            public async void should_fail_when_http_response_was_not_serializable()
            {
                var options = new MockMicroserviceOptions(defaultLocations: true);
                var httpClient = MockHttpClientFactory.Create(HttpStatusCode.OK, "any_string_here");

                var service = new ExternalTaxasProviderService(options.Object, httpClient);

                var result = await service.GetTaxaJuros();

                Assert.False(result.Succeeded);
            }

            [Fact]
            public async void should_succed_when_http_response_is_correct()
            {
                var taxaEsperada = 0.1m;
                var response = new Status<decimal>(value: taxaEsperada);
                var options = new MockMicroserviceOptions(defaultLocations: true);
                var httpClient = MockHttpClientFactory.Create(HttpStatusCode.OK, JsonConvert.SerializeObject(response));

                var service = new ExternalTaxasProviderService(options.Object, httpClient);

                var result = await service.GetTaxaJuros();

                Assert.True(result.Succeeded);
                Assert.Equal(taxaEsperada, result.Value);
            }
        }
    }
}
