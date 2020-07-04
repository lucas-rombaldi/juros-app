using System.Collections.Generic;

namespace JurosApp.SharedKernel.Microservices.Options
{
    /// <summary>
    /// Representa um objeto de configurações de microsserviços.
    /// </summary>
    public class MicroservicesOptions
    {
        public static readonly string MICROSERVICES_OPTION = "Microservices";

        public List<MicroserviceLocation> Locations { get; set; }
    }

    /// <summary>
    /// Representa uma "localização" de um microsserviço.
    /// </summary>
    public class MicroserviceLocation
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
