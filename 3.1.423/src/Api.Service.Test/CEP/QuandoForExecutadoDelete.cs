using System;
using Api.Domain.Interfaces.Services.CEP;
using Moq;
using Xunit;

namespace Api.Service.Test.CEP
{
    public class QuandoForExecutadoDelete : CEPTeste
    {
        private ICEPService _service;

        private Mock<ICEPService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método Delete")]
        public async void E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<ICEPService>();
            _serviceMock.Setup(x => x.Delete(IdCEP)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.Delete(IdCEP);
            Assert.True(result);

            _serviceMock = new Mock<ICEPService>();
            _serviceMock.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            result = await _service.Delete(Guid.NewGuid());
            Assert.False(result);
        }
    }
}
