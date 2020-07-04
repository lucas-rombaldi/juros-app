using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace JurosApp.SharedKernel.Api.Extensions
{
    /// <summary>
    /// Extensões de <see cref="IApplicationBuilder"/> para a utilização de API's.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configura os middlewares necessários para a utilização do Swagger/OpenAPI.
        /// </summary>
        /// <param name="app"><see cref="IApplicationBuilder"/> responsável pela pipeline da aplicação.</param>
        /// <param name="provider"><see cref="IApiDescriptionProvider"/> contendo os provedores de versões das API's.</param>
        public static void UseOpenApi(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
        }
    }
}
