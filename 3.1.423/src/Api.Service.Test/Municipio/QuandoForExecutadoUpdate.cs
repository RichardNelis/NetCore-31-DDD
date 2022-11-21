using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoUpdate : MunicipioTeste
    {
        private IMunicipioService _service;

        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método Update")]
        public async void E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(x => x.Put(municipioDTOUpdate)).ReturnsAsync(municipioDTOUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(municipioDTOUpdate);
            Assert.NotNull(result);
            Assert.Equal(NomeMunicipioAlterado, result.Nome);
            Assert.Equal(CodigoIBGEAlterado, result.CodIBGE);
            Assert.Equal(UFId, result.UFId);
        }
    }
}
