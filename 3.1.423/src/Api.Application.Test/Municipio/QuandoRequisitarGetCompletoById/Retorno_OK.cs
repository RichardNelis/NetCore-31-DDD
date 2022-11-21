using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarGetCompletoById
{
    public class Retorno_OK
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possível Realizar o GetCompletoById")]
        public async Task E_Possivel_Invocar_a_Controller_GetCompletoById()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(x => x.GetCompletoById(It.IsAny<Guid>())).ReturnsAsync(new MunicipioDTOCompleto
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
            });

            _controller = new MunicipiosController(serviceMock.Object);

            var result = await _controller.GetCompletoById(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }
    }
}
