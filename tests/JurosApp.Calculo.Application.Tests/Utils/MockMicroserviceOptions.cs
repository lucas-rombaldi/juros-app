using JurosApp.SharedKernel.Microservices;
using JurosApp.SharedKernel.Microservices.Options;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;

namespace JurosApp.Calculo.Application.Tests.Utils
{
    public class MockMicroserviceOptions : Mock<IOptions<MicroservicesOptions>>
    {
        public MockMicroserviceOptions(bool defaultLocations = false)
        {
            var options = new MicroservicesOptions();

            if (defaultLocations)
                options.Locations = new List<MicroserviceLocation>()
                {
                    {
                        new MicroserviceLocation()
                        {
                            Name = AvailableMicroservices.Taxas,
                            Location = "https://localhost:9999"
                        }
                    },
                    { 
                        new MicroserviceLocation()
                        {
                            Name = AvailableMicroservices.Calculo,
                            Location = "https://localhost:9999"
                        }
                    }
                };

            Setup(opt => opt.Value).Returns(options);
        }

        public MockMicroserviceOptions(List<MicroserviceLocation> microserviceLocations)
        {
            Setup(opt => opt.Value).Returns(new MicroservicesOptions()
            {
                Locations = microserviceLocations
            });
        }
    }
}
