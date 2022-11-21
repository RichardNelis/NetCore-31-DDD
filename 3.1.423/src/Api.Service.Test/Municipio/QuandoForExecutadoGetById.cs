using System;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGetById : MunicipioTeste
    {
        private IMunicipioService _service;

        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método GetById")]
        public async void E_Possivel_Executar_Metodo_GetById()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(x => x.GetCompletoById(IdMunicipio)).ReturnsAsync(municipioDTOCompleto);
            _service = _serviceMock.Object;

            var result = await _service.GetCompletoById(IdMunicipio);
            Assert.NotNull(result);
            Assert.True(result.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGE, result.CodIBGE);
            Assert.Equal(UFId, result.UFId);
            Assert.NotNull(result.UF);
            Assert.True(result.UF.Id != Guid.Empty);
        }
    }
}
