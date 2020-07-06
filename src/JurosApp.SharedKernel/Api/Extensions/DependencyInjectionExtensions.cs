using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using JurosApp.SharedKernel.Api.OpenApi;
using JurosApp.SharedKernel.Api.Versioning;
using System.Reflection;

namespace JurosApp.SharedKernel.Api.Extensions
{
    /// <summary>
    /// Métodos de extensão para registros no container de DI relacionados à API.
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Configura no container para suprimir filtros que retornem um BadRequest quando ModelState é inválido.
        /// </summary>
        /// <param name="container">O container onde o registro será realizado.</param>
        public static void SuppressModelStateInvalidFilter(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
        }

        /// <summary>
        /// Adiciona o versionamento de API à coleção de serviços.
        /// </summary>
        /// <param name="container">O container onde o registro será realizado.</param>
        public static void ConfigureApiVersioningByNamespace(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.ErrorResponses = new VersioningErrorResponse();
                config.Conventions.Add(new VersionByNamespaceConvention());
                config.ReportApiVersions = true;
            });
        }

        /// <summary>
        /// Configura a aplicação para o uso de API's versionadas e configuradas para o uso do OpenAPI (Swagger)
        /// </summary>
        /// <param name="services">Service Collection da aplicação</param>
        /// <param name="apiDocumentationXml">Nome do XML de documentação gerado pelo projeto.</param>
        public static void ConfigureApiVersioningWithOpenApi(
            this IServiceCollection services, 
            string documentationTitle, 
            string documentationDescription, 
            Assembly assembly)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddTransient((sp) => new OpenApiDocumentDescription(documentationTitle, documentationDescription));

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();
                var filePath = Path.Combine(AppContext.BaseDirectory, $"{assembly.GetName().Name}.xml");
                options.IncludeXmlComments(filePath);
            });

            services.ConfigureApiVersioningByNamespace();
        }
    }
}
