namespace JurosApp.Taxas.Application.Interfaces
{
    /// <summary>
    /// Responsável pela busca das taxas a ser utilizadas.
    /// </summary>
    public interface ITaxasService
    {
        /// <summary>
        /// Busca a taxa de juros padrão.
        /// </summary>
        /// <returns>Taxa de juros</returns>
        decimal GetTaxaJurosPadrao();
    }
}
