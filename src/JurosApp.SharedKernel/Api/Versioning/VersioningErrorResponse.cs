using JurosApp.SharedKernel.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace JurosApp.SharedKernel.Api.Versioning
{
    public class VersioningErrorResponse : DefaultErrorResponseProvider
    {
        /// <summary>
        /// Cria um <see cref="BadRequestObjectResult"/> contendo um <see cref="Status"/> com a mensagem de erro.
        /// </summary>
        /// <param name="context">Contexto da resposta de erro</param>
        /// <returns>Um <see cref="BadRequestObjectResult"/> contendo <see cref="Status"/>.</returns>
        public override IActionResult CreateResponse(ErrorResponseContext context)
        {
            var status = new Status(errorMessage: context.Message);
            return new BadRequestObjectResult(status);
        }
    }
}
