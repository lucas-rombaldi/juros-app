using Xunit;
using JurosApp.Calculo.Application.Services;

namespace JurosApp.Calculo.Application.Tests.Services
{
    public class CodeServiceTest
    {
        public class GetRepoUrl
        {
            [Fact]
            public async void should_get_fixed_url()
            {
                var service = new CodeService();
                Assert.Equal(CodeService.REPO_URL, await service.GetRepoUrl());
            }
        }
    }
}
