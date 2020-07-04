using JurosApp.SharedKernel.Commons;
using Microsoft.AspNetCore.Mvc;

namespace JurosApp.SharedKernel.Commons.Extensions
{
    /// <summary>
    /// Extension methods de <see cref="IActionResult"/>.
    /// </summary>
    public static class ActionResultExtensions
    {
        /// <summary>
        /// Verifica se o ActionResult deve ser "transformado" em um objeto de <see cref="Status"/>.
        /// </summary>
        /// <param name="actionResult"><see cref="IActionResult"/> com um retorno da webapi.</param>
        /// <returns><see cref="IActionResult"/> com um objeto <see cref="Status"/>.</returns>
        public static IActionResult ToStatusResult(this IActionResult actionResult)
        {
            if (actionResult is OkResult okResult)
                return okResult.ToStatusResult();

            if (actionResult is BadRequestResult badRequestResult)
                return badRequestResult.ToStatusResult();

            if (actionResult is NotFoundResult notFoundResult)
                return notFoundResult.ToStatusResult();

            return actionResult;
        }

        private static IActionResult ToStatusResult(this OkResult okResult)
        {
            return new OkObjectResult(new Status());
        }

        private static IActionResult ToStatusResult(this BadRequestResult badRequestResult)
        {
            var status = new Status
            {
                ErrorMessage = "Bad Request"
            };
            return new BadRequestObjectResult(status);
        }

        private static IActionResult ToStatusResult(this NotFoundResult badRequestResult)
        {
            var status = new Status
            {
                ErrorMessage = "Not Found"
            };
            return new NotFoundObjectResult(status);
        }
    }
}