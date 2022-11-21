using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;
using Api.Domain.Dtos.Municipio;
using System.Linq;
using System.Collections.Generic;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGetAll : MunicipioTeste
    {
        private IMunicipioService _service;

        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método GetAll.")]
        public async void E_Possivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(x => x.GetAll()).ReturnsAsync(municipioDTOs);
            _service = _serviceMock.Object;

            var _result = await _service.GetAll();
            Assert.NotNull(_result);
            Assert.True(municipioDTOs.Count() == 10);

            var _listResult = new List<MunicipioDTO>();

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(x => x.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
