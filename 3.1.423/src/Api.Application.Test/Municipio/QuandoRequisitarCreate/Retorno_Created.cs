using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarCreate
{
    public class Retorno_Created
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possível Realizar o Created")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(x => x.Post(It.IsAny<MunicipioDTOCreate>())).ReturnsAsync(
                new MunicipioDTOCreateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CreateAt = DateTime.UtcNow,
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");

            _controller.Url = url.Object;

            var municipioDTOCreate = new MunicipioDTOCreate
            {
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(100000, 999999)
            };

            var result = await _controller.Post(municipioDTOCreate);
            Assert.True(result is CreatedResult);
        }
    }
}
