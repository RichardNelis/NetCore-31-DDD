using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.CEP;
using Api.Domain.Interfaces.Services.CEP;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.CEP.QuandoRequisitarGetCompletoByCEP
{
    public class Retorno_BadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possível Realizar o GetCompletoByCEP")]
        public async Task E_Possivel_Invocar_a_Controller_GetCompletoByCEP()
        {
            var serviceMock = new Mock<ICEPService>();
            serviceMock.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(new CEPDTO
            {
                Id = Guid.NewGuid(),
                CEP = Faker.Address.UkPostCode(),
            });

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await _controller.Get(Faker.Address.UkPostCode());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
