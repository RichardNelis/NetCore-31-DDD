using Api.Domain.Interfaces.Services.CEP;
using Moq;
using Xunit;

namespace Api.Service.Test.CEP
{
    public class QuandoForExecutadoUpdate : CEPTeste
    {
        private ICEPService _service;

        private Mock<ICEPService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método Update")]
        public async void E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<ICEPService>();
            _serviceMock.Setup(x => x.Put(cepDTOUpdate)).ReturnsAsync(cepDTOUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(cepDTOUpdate);
            Assert.NotNull(result);
            Assert.Equal(CEPAlterado, result.CEP);
            Assert.Equal(LogradouroAlterado, result.Logradouro);
            Assert.Equal(NumeroAlterado, result.Numero);
        }
    }
}
