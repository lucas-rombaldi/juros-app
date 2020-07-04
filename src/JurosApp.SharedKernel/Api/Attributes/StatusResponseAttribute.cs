using Microsoft.AspNetCore.Mvc.Filters;
using JurosApp.SharedKernel.Commons.Extensions;

namespace JurosApp.SharedKernel.Api.Attributes
{
    /// <summary>
    /// Atributo criado para transformar o resultado dos contextos em um resultado padronizado.
    /// </summary>
    public class StatusResponseAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Valida o ModelState, retornando um BadRequest contendo um objeto de <see cref="Status"/> caso não seja válido.
        /// </summary>
        /// <param name="context">Contexto em execução da action.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
                context.Result = context.ModelState.ToBadRequestResult();

            base.OnActionExecuting(context);
        }

        /// <summary>
        /// Tranforma o resultado em um objeto de <see cref="Status"/>.
        /// </summary>
        /// <param name="context">Contexto de execução da action.</param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context?.Result != null)
                context.Result = context.Result.ToStatusResult();

            base.OnActionExecuted(context);
        }
    }
}
