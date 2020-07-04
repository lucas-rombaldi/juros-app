using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace JurosApp.SharedKernel.Api.OpenApi
{
    /// <summary>
    /// Representa um <see cref="IOperationFilter"/> utilizado para documentar o parâmetro de versão.
    /// </summary>
    public class SwaggerDefaultValues : IOperationFilter
    {
        /// <summary>
        /// Aplica o filtro na operação de acordo com o contexto.
        /// </summary>
        /// <param name="operation">Operação para aplicar o filtro.</param>
        /// <param name="context">Contexto de filtros da operação</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiDescription = context.ApiDescription;

            operation.Deprecated |= apiDescription.IsDeprecated();

            if (operation.Parameters == null)
                return;

            foreach (var parameter in operation.Parameters)
            {
                var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                if (parameter.Description == null)
                    parameter.Description = description.ModelMetadata?.Description;

                if (parameter.Schema.Default == null && description.DefaultValue != null)
                    parameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());

                parameter.Required |= description.IsRequired;
            }
        }
    }
}