using System;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoDelete : MunicipioTeste
    {
        private IMunicipioService _service;

        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método Delete")]
        public async void E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(x => x.Delete(IdMunicipio)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.Delete(IdMunicipio);
            Assert.True(result);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            result = await _service.Delete(Guid.NewGuid());
            Assert.False(result);
        }
    }
}
