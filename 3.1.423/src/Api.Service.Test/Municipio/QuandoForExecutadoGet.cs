using System.Threading.Tasks;
using System;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;
using Api.Domain.Dtos.Municipio;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGet : MunicipioTeste
    {
        private IMunicipioService _service;

        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método Get.")]
        public async void E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(x => x.Get(IdMunicipio)).ReturnsAsync(municipioDTO);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdMunicipio);
            Assert.NotNull(result);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGE, result.CodIBGE);
            Assert.Equal(UFId, result.UFId);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDTO)null));
            _service = _serviceMock.Object;

            result = await _service.Get(Guid.NewGuid());
            Assert.Null(result);
        }
    }
}
