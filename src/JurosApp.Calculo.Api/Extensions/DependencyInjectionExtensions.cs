using Microsoft.Extensions.DependencyInjection;
using JurosApp.Calculo.Application.Services;
using JurosApp.Calculo.Application.Interfaces;

namespace JurosApp.Calculo.Api.Extensions
{
    /// <summary>
    /// Métodos de extensão relacionados à injeção de dependências.
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Realiza o registro dos serviços utilizados por este projeto.
        /// </summary>
        /// <param name="services">Container de DI</param>
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ICalculoService, CalculoService>();
            services.AddSingleton<ICodeService, CodeService>();
            services.AddHttpClient<ITaxasProviderService, ExternalTaxasProviderService>();
        }
    }
}
