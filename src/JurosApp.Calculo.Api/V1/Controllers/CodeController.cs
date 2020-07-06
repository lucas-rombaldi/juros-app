using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JurosApp.Calculo.Application.Interfaces;
using JurosApp.SharedKernel.Api;
using JurosApp.SharedKernel.Commons;
using Microsoft.AspNetCore.Http;

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
        /// <response code="200">Objeto "Status" contendo a URL do repositório.</response>
        [HttpGet]
        [ProducesResponseType(typeof(Status<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _codeService.GetRepoUrl());
        }
    }
}
