
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace JurosApp.SharedKernel.Api.OpenApi
{
    /// <summary>
    /// Configura as opções de geração do Swagger.
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        private readonly OpenApiDocumentDescription _openApiDocumentDescription;

        public ConfigureSwaggerOptions(
            IApiVersionDescriptionProvider provider, 
            OpenApiDocumentDescription openApiDocumentDescription) 
        {
            _provider = provider;
            _openApiDocumentDescription = openApiDocumentDescription;
        }

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description, _openApiDocumentDescription));
            }
        }

        /// <summary>
        /// Mantém o <see cref="OpenApiInfo"/> para esta API.
        /// </summary>
        /// <param name="description">Versão utilizada pela API</param>
        /// <param name="openApiDocumentDescription"><see cref="OpenApiDocumentDescription"/> contendo algumas informações para configuração da API no Swagger</param>
        /// <returns></returns>
        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description, OpenApiDocumentDescription openApiDocumentDescription)
        {
            var info = new OpenApiInfo()
            {
                Title = openApiDocumentDescription.Title,
                Version = description.ApiVersion.ToString(),
                Description = openApiDocumentDescription.Description,
                Contact = new OpenApiContact() { Name = "Lucas Rombaldi", Email = "lucas.rombaldi@gmail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}