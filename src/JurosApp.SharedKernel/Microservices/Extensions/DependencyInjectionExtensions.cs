using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JurosApp.SharedKernel.Microservices.Options;

namespace JurosApp.SharedKernel.Microservices.Extensions
{
    /// <summary>
    /// Realiza os registros no container para as funcionalidades relacionadas aos microsserviços.
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Realiza a configuração das opções relacionadas aos microsserviços.
        /// </summary>
        /// <param name="services">Container para registro</param>
        /// <param name="configuration"><see cref="IConfiguration"/> utilizado para buscar as opções</param>
        public static void ConfigureMicroservicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MicroservicesOptions>(configuration.GetSection(MicroservicesOptions.MICROSERVICES_OPTION));
        }
    }
}
