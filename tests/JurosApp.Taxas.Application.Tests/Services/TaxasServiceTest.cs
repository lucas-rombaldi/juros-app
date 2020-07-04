using Xunit;
using JurosApp.Taxas.Application.Services;

namespace JurosApp.Taxas.Application.Tests.Services
{
    public class TaxasServiceTest
    {
        public class GetTaxaJurosPadrao
        { 
            [Fact]
            public void should_get_taxa_juros_padrao()
            {
                var service = new TaxasService();
                Assert.Equal(TaxasService.TAXA_JUROS_PADRAO, service.GetTaxaJurosPadrao());
            }
        }
    }
}
