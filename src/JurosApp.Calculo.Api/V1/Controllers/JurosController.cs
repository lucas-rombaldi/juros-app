using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JurosApp.Calculo.Api.V1.Models;
using JurosApp.Calculo.Application.Interfaces;
using JurosApp.SharedKernel.Api;

namespace JurosApp.Calculo.Api.V1.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    public class JurosController : JurosBaseController
    {
        private readonly ICalculoService _calculoService;

        public JurosController(ICalculoService calculoService)
        {
            _calculoService = calculoService;
        }

        /// <summary>
        /// Realiza o cálculo de juros de uma operação.
        /// </summary>
        /// <param name="calculaJurosDTO">Dados para realizar o cálculo de juros.</param>
        /// <returns>Valor calculado com os juros aplicados.</returns>
        [HttpGet]
        [Route("calculaJuros")]
        public async Task<IActionResult> CalculaJuros([FromQuery] CalculaJurosDTO calculaJurosDTO)
        {
            return Ok(await _calculoService.CalculaJuros(calculaJurosDTO.ValorInicial.Value, calculaJurosDTO.Meses.Value));
        }
    }
}
