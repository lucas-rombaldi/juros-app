using System.Linq;
using Microsoft.Extensions.Options;
using JurosApp.SharedKernel.Microservices.Options;

namespace JurosApp.SharedKernel.Microservices
{
    /// <summary>
    /// Representa a lista e os microsserviços disponíveis (a ser descartado futuramente com a utilização de algum serviço de Service Discovery).
    /// </summary>
    public static class AvailableMicroservices
    {
        public static readonly string Taxas = "Taxas";

        public static readonly string Calculo = "Calculo";

        /// <summary>
        /// Retorna um <see cref="MicroserviceLocation"/> referente à um determinado microsserviço.
        /// </summary>
        /// <param name="microservicesOptions">Opções configuradas dos microsserviços</param>
        /// <param name="name">Nome do microsserviço a ser buscado</param>
        /// <returns>O <see cref="MicroserviceLocation"/> referente à um determinado microsserviço.</returns>
        public static MicroserviceLocation GetMicroserviceLocation(this IOptions<MicroservicesOptions> microservicesOptions, string name)
        {
            return microservicesOptions.Value.Locations.FirstOrDefault(ms => ms.Name.Equals(name));
        }
    }
}
