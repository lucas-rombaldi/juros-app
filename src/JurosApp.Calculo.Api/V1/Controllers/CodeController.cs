using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JurosApp.Calculo.Application.Interfaces;
using JurosApp.SharedKernel.Api;

namespace JurosApp.Calculo.Api.V1.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/showmethecode")]
    public class CodeController : JurosBaseController
    {
        private readonly ICodeService _codeService;

        public CodeController(ICodeService codeService)
        {
            _codeService = codeService;
        }

        /// <summary>
        /// Retorna a URL do repositório do GitHub contendo o código fonte desta aplicação.
        /// </summary>
        /// <returns>URL do repositório do GitHub</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _codeService.GetRepoUrl());
        }
    }
}
