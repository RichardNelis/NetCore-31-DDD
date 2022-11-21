using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.UF;
using Xunit;
using Moq;
using System;
using Api.Domain.Dtos.UF;

namespace Api.Service.Test.UF
{
    public class QuandoForExecutarGet : UFTeste
    {
        private IUFService _service;

        private Mock<IUFService> _serviceMock;

        [Fact(DisplayName = "É Possível Executar o Método GET.")]
        public async void E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IUFService>();
            _serviceMock.Setup(x => x.Get(Id)).ReturnsAsync(UF);
            _service = _serviceMock.Object;

            var result = await _service.Get(Id);
            Assert.NotNull(result);
            Assert.True(result.Id == Id);
            Assert.Equal(Nome, result.Nome);

            _serviceMock = new Mock<IUFService>();
            _serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UFDTO)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Id);
            Assert.Null(_record);
        }
    }
}
