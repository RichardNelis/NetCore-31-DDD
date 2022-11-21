using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoCreate : MunicipioTeste
    {
        private IMunicipioService _service;

        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método Create.")]
        public async void E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(x => x.Post(municipioDTOCreate)).ReturnsAsync(municipioDTOCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(municipioDTOCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGE, result.CodIBGE);
            Assert.Equal(UFId, result.UFId);
        }
    }
}
