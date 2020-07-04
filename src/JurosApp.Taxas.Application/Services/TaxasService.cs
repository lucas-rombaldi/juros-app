using JurosApp.Taxas.Application.Interfaces;

namespace JurosApp.Taxas.Application.Services
{
    /// <inheritdoc cref="ITaxasService">
    public class TaxasService : ITaxasService
    {
        public static readonly decimal TAXA_JUROS_PADRAO = 0.01m;

        /// <summary>
        /// Retorna a taxa de juros padrão configurada na aplicação.
        /// </summary>
        /// <returns>Taxa de juros padrão</returns>
        public decimal GetTaxaJurosPadrao() => TAXA_JUROS_PADRAO;
    }
}
