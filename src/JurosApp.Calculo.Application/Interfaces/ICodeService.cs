using System.Threading.Tasks;

namespace JurosApp.Calculo.Application.Interfaces
{
    /// <summary>
    /// Responsável pelos serviços relacionados ao código-fonte.
    /// </summary>
    public interface ICodeService
    {
        /// <summary>
        /// Busca a URL do repositório em que este código está armazenado.
        /// </summary>
        /// <returns>URL do repositório</returns>
        Task<string> GetRepoUrl();
    }
}
