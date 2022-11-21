using Api.Domain.Interfaces.Services.CEP;
using Moq;
using Xunit;

namespace Api.Service.Test.CEP
{
    public class QuandoForExecutadoCreate : CEPTeste
    {
        private ICEPService _service;

        private Mock<ICEPService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método Create.")]
        public async void E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<ICEPService>();
            _serviceMock.Setup(x => x.Post(cepDTOCreate)).ReturnsAsync(cepDTOCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(cepDTOCreate);
            Assert.NotNull(result);
            Assert.Equal(CEPOriginal, result.CEP);
            Assert.Equal(LogradouroOriginal, result.Logradouro);
            Assert.Equal(NumeroOriginal, result.Numero);
        }
    }
}
