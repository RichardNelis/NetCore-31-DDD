
using System.Collections.Generic;
using Api.Application.Controllers;
using Api.Domain.Dtos.UF;
using Api.Domain.Interfaces.Services.UF;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.UF.QuandoRequisitarGetAll
{
    public class Retorno_NotFound
    {
        private UFsController _controller;

        [Fact(DisplayName = "É possível realizar o GetAll")]
        public async void E_Possivel_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<IUFService>();

            serviceMock.Setup(x => x.GetAll()).ReturnsAsync((List<UFDTO>)null);

            _controller = new UFsController(serviceMock.Object);

            var result = await _controller.GetAll();
            Assert.True(result is NotFoundResult);
        }
    }
}
