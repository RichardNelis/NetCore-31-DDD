using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UFGets : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UFGets(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Gets de UF")]
        [Trait("Gets", "UFEntity")]
        public async Task E_Possivel_RealizarGets_UF()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UFImplementation _repository = new UFImplementation(context);
                UFEntity _entity = new UFEntity()
                {
                    Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                    Sigla = "SP",
                    Nome = "São Paulo"
                };

                var _registroExiste = await _repository.ExistAsync(_entity.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repository.SelectAsync(_entity.Id);
                Assert.NotNull(_registroExiste);
                Assert.Equal(_entity.Sigla, _registroSelecionado.Sigla);
                Assert.Equal(_entity.Nome, _registroSelecionado.Nome);
                Assert.Equal(_entity.Id, _registroSelecionado.Id);

                var _todosRegistros = await _repository.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() == 27);
            }
        }
    }
}
