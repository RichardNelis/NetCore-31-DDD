using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.CEP;
using Api.Domain.Interfaces.Services.CEP;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.CEP.QuandoRequisitarUpdate
{
    public class Retorno_BadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possível Realizar o Update")]
        public async Task E_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<ICEPService>();
            serviceMock.Setup(x => x.Put(It.IsAny<CEPDTOUpdate>())).ReturnsAsync(
                new CEPDTOUpdateResult
                {
                    Id = Guid.NewGuid(),
                    CEP = Faker.Address.UkPostCode(),
                    UpdateAt = DateTime.UtcNow,
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Nome", "É um campo obrigatório");

            var cepDTOUpdate = new CEPDTOUpdate
            {
                CEP = Faker.Address.UkPostCode(),
            };

            var result = await _controller.Put(cepDTOUpdate);
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
