using JurosApp.Calculo.Application.Interfaces;
using JurosApp.SharedKernel.Commons;
using System;
using System.Threading.Tasks;

namespace JurosApp.Calculo.Application.Services
{
    /// <inheritdoc cref="ICalculoService"/>
    public class CalculoService : ICalculoService
    {
        private readonly ITaxasProviderService _taxasProviderService;

        public CalculoService(ITaxasProviderService taxasProviderService)
        {
            _taxasProviderService = taxasProviderService;
        }

        /// <inheritdoc cref="ICalculoService.CalculaJuros(decimal, int)"/>
        public async Task<Status<decimal>> CalculaJuros(decimal valorInicial, int meses)
        {
            if (valorInicial == 0) return new Status<decimal>(errorMessage: $"O parâmetro {nameof(valorInicial)} deve ser maior que zero.");
            if (meses == 0) return new Status<decimal>(errorMessage: $"O parâmetro {nameof(meses)} deve ser maior que zero."); 

            var taxaJuros = await _taxasProviderService.GetTaxaJuros();
            if (!taxaJuros) return new Status<decimal>(errorMessage: taxaJuros.ErrorMessage);

            try
            {
                var valorFinal = CalculaValorFinal(taxaJuros.Value, valorInicial, meses);
                return new Status<decimal>(valorFinal);
            }
            catch (Exception e)
            {
                return new Status<decimal>(errorMessage: $"Ocorreu uma falha no cálculo de juros: {e.Message}");
            }            
        }

        /// <summary>
        /// Realiza o cálculo completo do valor final com juros.
        /// </summary>
        /// <param name="taxaJuros">Taxa de juros a ser aplicada.</param>
        /// <param name="valorInicial">Valor base para o cálculo.</param>
        /// <param name="meses">Número de meses para cálculo.</param>
        /// <returns>Valor final com juros</returns>
        private decimal CalculaValorFinal(decimal taxaJuros, decimal valorInicial, int meses)
        {
            var percentualJuros = (decimal)Math.Pow((double)(1 + taxaJuros), meses);
            return Math.Truncate(valorInicial * percentualJuros * 100) / 100;
        }
    }
}
