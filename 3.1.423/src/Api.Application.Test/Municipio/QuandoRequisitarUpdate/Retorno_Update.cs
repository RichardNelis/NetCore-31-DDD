using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarUpdate
{
    public class Retorno_Update
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possível Realizar o Update")]
        public async Task E_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(x => x.Put(It.IsAny<MunicipioDTOUpdate>())).ReturnsAsync(
                new MunicipioDTOUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    UpdateAt = DateTime.UtcNow,
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);

            var municipioDTOUpdate = new MunicipioDTOUpdate
            {
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(100000, 999999)
            };

            var result = await _controller.Put(municipioDTOUpdate);
            Assert.True(result is OkObjectResult);
        }
    }
}
