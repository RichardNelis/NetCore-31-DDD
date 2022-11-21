using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.CEP;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.CEP.QuandoRequisitarDelete
{
    public class Retorno_BadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possível Realizar o Delete")]
        public async Task E_Possivel_Invocar_a_Controller_Delete()
        {
            var serviceMock = new Mock<ICEPService>();
            serviceMock.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
