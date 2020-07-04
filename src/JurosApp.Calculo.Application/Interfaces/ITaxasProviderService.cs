using JurosApp.SharedKernel.Commons;
using System.Threading.Tasks;

namespace JurosApp.Calculo.Application.Interfaces
{
    /// <summary>
    /// Representa os serviços para prover as taxas para cálculo.
    /// </summary>
    public interface ITaxasProviderService
    {
        /// <summary>
        /// Busca a taxa de juros a ser aplicada.
        /// </summary>
        /// <returns>Taxa de juros</returns>
        Task<Status<decimal>> GetTaxaJuros();
    }
}
