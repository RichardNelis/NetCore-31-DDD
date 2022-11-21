using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.CEP;
using Api.Domain.Interfaces.Services.CEP;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.CEP.QuandoRequisitarGet
{
    public class Retorno_OK
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possível Realizar o Get")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<ICEPService>();
            serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(new CEPDTO
            {
                Id = Guid.NewGuid(),
                CEP = Faker.Address.UkPostCode(),
            });

            _controller = new CepsController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }
    }
}
