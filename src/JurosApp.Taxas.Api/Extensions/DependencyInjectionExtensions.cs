using JurosApp.Taxas.Application.Interfaces;
using JurosApp.Taxas.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JurosApp.Taxas.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ITaxasService, TaxasService>();
        }
    }
}
