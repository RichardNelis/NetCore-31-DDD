using System;
using System.Collections.Generic;
using Api.Application.Controllers;
using Api.Domain.Dtos.UF;
using Api.Domain.Interfaces.Services.UF;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.UF.QuandoRequisitarGetAll
{
    public class Retorno_BadRequest
    {
        private UFsController _controller;

        [Fact(DisplayName = "É possível realizar o GetAll")]
        public async void E_Possivel_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<IUFService>();

            serviceMock.Setup(x => x.GetAll()).ReturnsAsync(
                new List<UFDTO>
                {
                    new UFDTO
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.City(),
                        Sigla = Faker.Address.UsState(),
                    },
                    new UFDTO
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.City(),
                        Sigla = Faker.Address.UsState(),
                    },
                }
            );

            _controller = new UFsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
