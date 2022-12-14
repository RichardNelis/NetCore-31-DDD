using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarGet
{
    public class Retorno_NotFound
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possível Realizar o Get")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync((MunicipioDTO)null);

            _controller = new MunicipiosController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }
    }
}
