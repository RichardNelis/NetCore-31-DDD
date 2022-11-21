using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarGetCompletoByIBGE
{
    public class Retorno_NotFound
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possível Realizar o GetCompletoByIBGE")]
        public async Task E_Possivel_Invocar_a_Controller_GetCompletoByIBGE()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(x => x.GetCompletoByIBGE(It.IsAny<int>())).ReturnsAsync((MunicipioDTOCompleto)null);

            _controller = new MunicipiosController(serviceMock.Object);

            var result = await _controller.GetCompletoByIBGE(1);
            Assert.True(result is NotFoundResult);
        }
    }
}
