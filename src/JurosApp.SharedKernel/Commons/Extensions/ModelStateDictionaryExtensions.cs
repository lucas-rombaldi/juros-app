using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JurosApp.SharedKernel.Commons.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        /// <summary>
        /// Agrupa todos os erros de um <see cref="ModelStateDictionary"/> em um <see cref="Status"/> retornando ele em um BadRequest.
        /// </summary>
        /// <param name="modelStateDictionary">O dicionário de estados.</param>
        /// <returns>Um <see cref="Status"/> contendo as mensagens de erro do dicionário.</returns>
        public static IActionResult ToBadRequestResult(this ModelStateDictionary modelStateDictionary)
        {
            var errorMessages = modelStateDictionary.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage);
            var resultErrorMessage = string.Join(Environment.NewLine, errorMessages);

            return new BadRequestObjectResult(new Status(errorMessage: resultErrorMessage));
        }
    }
}
