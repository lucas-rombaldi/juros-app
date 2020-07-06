using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JurosApp.SharedKernel.Api.Extensions;
using JurosApp.SharedKernel.Commons.Extensions;
using JurosApp.SharedKernel.Microservices.Extensions;
using JurosApp.Taxas.Api.Extensions;

namespace JurosApp.Taxas.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.ConfigureApiVersioningWithOpenApi(
                documentationTitle: "JurosApp - API de Taxas",
                documentationDescription: "API de Taxas",
                assembly: typeof(Startup).Assembly);

            services.ConfigureMicroservicesConfiguration(Configuration);

            services.SuppressModelStateInvalidFilter();

            services.RegisterServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseStatusExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi(provider);
        }
    }
}
