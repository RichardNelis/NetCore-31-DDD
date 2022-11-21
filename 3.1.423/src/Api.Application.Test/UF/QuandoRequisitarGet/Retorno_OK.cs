using System;
using Api.Application.Controllers;
using Api.Domain.Dtos.UF;
using Api.Domain.Interfaces.Services.UF;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.UF.QuandoRequisitarGet
{
    public class Retorno_OK
    {
        private UFsController _controller;

        [Fact(DisplayName = "É possível realizar o GET")]
        public async void E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IUFService>();

            serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(new UFDTO
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                Sigla = Faker.Address.UsState(),
            });

            _controller = new UFsController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }
    }
}
