using Microsoft.AspNetCore.Mvc;
using JurosApp.SharedKernel.Api;
using JurosApp.Taxas.Application.Interfaces;
using JurosApp.SharedKernel.Commons;
using Microsoft.AspNetCore.Http;

namespace JurosApp.Taxas.Api.V1.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/taxaJuros")]
    public class TaxaJurosController : JurosBaseController
    {
        private readonly ITaxasService _taxasService;

        public TaxaJurosController(ITaxasService taxasService)
        {
            _taxasService = taxasService;
        }

        /// <summary>
        /// Retorna a taxa de juros padrão da aplicação.
        /// </summary>
        /// <returns>Taxa de juros padrão</returns>
        /// <response code="200">Objeto "Status" contendo a taxa de juros.</response>
        [HttpGet]
        [ProducesResponseType(typeof(Status<decimal>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_taxasService.GetTaxaJurosPadrao());
        }
    }
}
