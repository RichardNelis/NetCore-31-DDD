using System.Threading.Tasks;
using System;
using Moq;
using Xunit;
using Api.Domain.Interfaces.Services.CEP;
using Api.Domain.Dtos.CEP;

namespace Api.Service.Test.CEP
{
    public class QuandoForExecutadoGet : CEPTeste
    {
        private ICEPService _service;

        private Mock<ICEPService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método Get.")]
        public async void E_Possivel_Executar_Metodo_Get()
        {
            //Consulta ID
            _serviceMock = new Mock<ICEPService>();
            _serviceMock.Setup(x => x.Get(IdCEP)).ReturnsAsync(cepDTO);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdCEP);
            Assert.NotNull(result);
            Assert.True(result.Id == IdCEP);
            Assert.Equal(CEPOriginal, result.CEP);
            Assert.Equal(LogradouroOriginal, result.Logradouro);

            //Consulta CEP
            _serviceMock = new Mock<ICEPService>();
            _serviceMock.Setup(x => x.Get(CEPOriginal)).ReturnsAsync(cepDTO);
            _service = _serviceMock.Object;

            result = await _service.Get(CEPOriginal);
            Assert.NotNull(result);
            Assert.True(result.Id == IdCEP);
            Assert.Equal(CEPOriginal, result.CEP);
            Assert.Equal(LogradouroOriginal, result.Logradouro);

            _serviceMock = new Mock<ICEPService>();
            _serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CEPDTO)null));
            _service = _serviceMock.Object;

            result = await _service.Get(Guid.NewGuid());
            Assert.Null(result);
        }
    }
}
