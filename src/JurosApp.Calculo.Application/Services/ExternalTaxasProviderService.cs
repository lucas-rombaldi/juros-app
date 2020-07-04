using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using JurosApp.Calculo.Application.Interfaces;
using JurosApp.SharedKernel.Commons;
using JurosApp.SharedKernel.Microservices;
using JurosApp.SharedKernel.Microservices.Options;

namespace JurosApp.Calculo.Application.Services
{
    /// <summary>
    /// Implementa um <see cref="ITaxasProviderService"/> que obtém as taxas através do microsserviço de taxas.
    /// </summary>
    public class ExternalTaxasProviderService : ITaxasProviderService
    {
        private readonly IOptions<MicroservicesOptions> _microservicesOptions;
        private readonly HttpClient _httpClient;

        public ExternalTaxasProviderService(IOptions<MicroservicesOptions> microservicesOptions, HttpClient httpClient)
        {
            _microservicesOptions = microservicesOptions;
            _httpClient = httpClient;
        }

        /// <inheritdoc cref="ITaxasProviderService.GetTaxaJuros">
        public async Task<Status<decimal>> GetTaxaJuros()
        {
            Status<decimal> status;
            try
            {
                var content = await CallTaxasMicroservice();
                status = JsonConvert.DeserializeObject<Status<decimal>>(content);
            }
            catch (Exception e)
            {
                return new Status<decimal>(errorMessage: $"Ocorreu um problema na consulta do microsserviço de taxas. {e.Message}");
            }            

            return new Status<decimal>(value: status.Value);
        }

        /// <summary>
        /// Realiza a chamada para o microsserviço de taxas para obter a taxa padrão.
        /// </summary>
        /// <returns>Conteúdo da resposta da requisição.</returns>
        private async Task<string> CallTaxasMicroservice()
        {
            var taxasMicroserviceLocation = _microservicesOptions.GetMicroserviceLocation(AvailableMicroservices.Taxas);
            if (taxasMicroserviceLocation == null)
                throw new NullReferenceException("Não foi encontrada a URL para o microsserviço de taxas.");

            var uri = $@"{taxasMicroserviceLocation.Location}/taxaJuros";
            var result = await _httpClient.GetAsync(uri);
            if (!result.IsSuccessStatusCode)
                throw new HttpRequestException($"Código de falha: {result.StatusCode}");

            return await result.Content.ReadAsStringAsync();
        }
    }
}
