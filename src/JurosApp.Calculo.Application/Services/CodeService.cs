using JurosApp.Calculo.Application.Interfaces;
using JurosApp.SharedKernel.Commons;
using System.Threading.Tasks;

namespace JurosApp.Calculo.Application.Services
{
    /// <inheritdoc cref="ICodeService">
    public class CodeService : ICodeService
    {
        public static readonly string REPO_URL = @"https://github.com/lucas-rombaldi/juros-app";

        /// <inheritdoc cref="ICodeService.GetRepoUrl">
        public async Task<Status<string>> GetRepoUrl()
        {
            await Task.CompletedTask;
            return new Status<string>(value: REPO_URL);
        }
    }
}
