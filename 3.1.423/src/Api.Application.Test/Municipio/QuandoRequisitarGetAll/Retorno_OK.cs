using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarGetAll
{
    public class Retorno_OK
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possível Realizar o GetAll")]
        public async Task E_Possivel_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(x => x.GetAll()).ReturnsAsync(
                new List<MunicipioDTO>
                {
                    new MunicipioDTO
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.City(),
                    },
                    new MunicipioDTO
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.City(),
                    },
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);
        }
    }
}
