using System.Collections.Generic;
using Api.Domain.Interfaces.Services.UF;
using Xunit;
using Moq;
using Api.Domain.Dtos.UF;
using System.Linq;

namespace Api.Service.Test.UF
{
    public class QuandoForExecutarGetAll : UFTeste
    {
        private IUFService _service;

        private Mock<IUFService> _serviceMock;

        [Fact(DisplayName = "É Possível Executar o Método GETAll.")]
        public async void E_Possivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IUFService>();
            _serviceMock.Setup(x => x.GetAll()).ReturnsAsync(ListaUF);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<UFDTO>();

            _serviceMock = new Mock<IUFService>();
            _serviceMock.Setup(x => x.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
