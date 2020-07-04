using System.Threading.Tasks;
using Moq;
using Xunit;
using JurosApp.Calculo.Application.Interfaces;
using JurosApp.Calculo.Application.Services;
using JurosApp.SharedKernel.Commons;

namespace JurosApp.Calculo.Application.Tests.Services
{
    public class CalculoServiceTest
    {
        public class CalculaJuros
        {
            [Fact]
            public async void should_fail_when_valor_inicial_is_equal_to_zero()
            {
                var mockTaxasService = new Mock<ITaxasProviderService>();
                var service = new CalculoService(mockTaxasService.Object);

                var result = await service.CalculaJuros(0, 10);

                Assert.False(result.Succeeded);
            }

            [Fact]
            public async void should_fail_when_meses_is_equal_to_zero()
            {
                var mockTaxasService = new Mock<ITaxasProviderService>();
                var service = new CalculoService(mockTaxasService.Object);

                var result = await service.CalculaJuros(10, 0);

                Assert.False(result.Succeeded);
            }

            [Fact]
            public async void should_fail_when_args_is_equal_to_zero()
            {
                var mockTaxasService = new Mock<ITaxasProviderService>();
                var service = new CalculoService(mockTaxasService.Object);

                var result = await service.CalculaJuros(0, 0);

                Assert.False(result.Succeeded);
            }

            [Fact]
            public async void should_fail_when_taxas_provider_fails()
            {
                var errorMessage = "test message";
                var mockTaxasService = new Mock<ITaxasProviderService>();
                mockTaxasService.Setup(srv => srv.GetTaxaJuros()).Returns(Task.FromResult(new Status<decimal>(errorMessage: errorMessage)));
                var service = new CalculoService(mockTaxasService.Object);

                var result = await service.CalculaJuros(10, 10);

                Assert.False(result.Succeeded);
                Assert.Equal(errorMessage, result.ErrorMessage);
            }

            [Theory]
            [InlineData(100, 5, 0.01, 105.1)]
            [InlineData(100, 40, 0.01, 148.88)]
            [InlineData(5.47, 40, 0.01, 8.14)]
            [InlineData(500, 37, 0.0142, 842.44)]
            [InlineData(153600, 1, 0.01, 155136)]
            [InlineData(1500.98, 129, 0.079, 27298656.23)]
            [InlineData(1938.45, 250, 0.053, 784417727.1)]
            [InlineData(165498.5, 9, 0.0956, 376410.97)]
            [InlineData(252663.12, 19, 0.042, 552113.68)]
            [InlineData(98777.9, 3, 0.057, 116650)]
            public async void should_calculate_interests_according_to_args_and_tax(decimal valorInicial, int meses, decimal taxaJuros, decimal valorFinalEsperado)
            {
                var mockTaxasService = new Mock<ITaxasProviderService>();
                mockTaxasService.Setup(srv => srv.GetTaxaJuros()).Returns(Task.FromResult(new Status<decimal>(taxaJuros)));
                var service = new CalculoService(mockTaxasService.Object);

                var result = await service.CalculaJuros(valorInicial, meses);

                Assert.True(result.Succeeded);
                Assert.Equal(valorFinalEsperado, result.Value);
            }
        }
    }
}
