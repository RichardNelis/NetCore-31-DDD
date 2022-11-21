using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.CEP;
using Api.Domain.Interfaces.Services.CEP;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.CEP.QuandoRequisitarCreate
{
    public class Retorno_Created
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possível Realizar o Created")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<ICEPService>();
            serviceMock.Setup(x => x.Post(It.IsAny<CEPDTOCreate>())).ReturnsAsync(
                new CEPDTOCreateResult
                {
                    Id = Guid.NewGuid(),
                    CEP = Faker.Address.UkPostCode(),
                    CreateAt = DateTime.UtcNow,
                }
            );

            _controller = new CepsController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");

            _controller.Url = url.Object;

            var cepDTOCreate = new CEPDTOCreate
            {
                CEP = Faker.Address.UkPostCode(),
            };

            var result = await _controller.Post(cepDTOCreate);
            Assert.True(result is CreatedResult);
        }
    }
}
