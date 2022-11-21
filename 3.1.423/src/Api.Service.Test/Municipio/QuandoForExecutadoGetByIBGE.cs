using System;
using System.Reflection;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGetByIBGE : MunicipioTeste
    {
        private IMunicipioService _service;

        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método GetByIBGE.")]
        public async void E_Possivel_Executar_Metodo_GetByIBGE()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(x => x.GetCompletoByIBGE(CodigoIBGE)).ReturnsAsync(municipioDTOCompleto);
            _service = _serviceMock.Object;

            var result = await _service.GetCompletoByIBGE(CodigoIBGE);
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
