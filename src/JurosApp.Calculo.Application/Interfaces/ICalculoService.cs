using JurosApp.SharedKernel.Commons;
using System.Threading.Tasks;

namespace JurosApp.Calculo.Application.Interfaces
{
    /// <summary>
    /// Responsável pela realização dos serviços relacionados ao cálculo.
    /// </summary>
    public interface ICalculoService
    {
        /// <summary>
        /// Realiza o cálculo de juros.
        /// </summary>
        /// <param name="valorInicial">Valor base para o cálculo.</param>
        /// <param name="meses">Quantidade de meses para calcular.</param>
        /// <returns>Valor reajustado de acordo com os juros</returns>
        Task<Status<decimal>> CalculaJuros(decimal valorInicial, int meses);
    }
}
