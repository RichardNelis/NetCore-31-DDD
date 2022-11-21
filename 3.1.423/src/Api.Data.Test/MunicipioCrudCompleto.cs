using System;
using System.Linq;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class MunicipioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public MunicipioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD do Município")]
        [Trait("CRUD", "MunicipioEntity")]
        public async void E_Possivel_Realizar_CRUD_Municipio()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                MunicipioImplementation _repository = new MunicipioImplementation(context);
                MunicipioEntity _entity = new MunicipioEntity()
                {
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                    UFId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                };

                var _registroCriado = await _repository.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Nome, _registroCriado.Nome);
                Assert.Equal(_entity.CodIBGE, _registroCriado.CodIBGE);
                Assert.Equal(_entity.UFId, _registroCriado.UFId);
                Assert.False(_entity.Id == Guid.Empty);

                _entity.Nome = Faker.Address.City();
                _entity.Id = _registroCriado.Id;
                var _registroAtualizado = await _repository.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Nome, _registroAtualizado.Nome);
                Assert.Equal(_entity.CodIBGE, _registroAtualizado.CodIBGE);
                Assert.Equal(_entity.UFId, _registroAtualizado.UFId);
                Assert.True(_entity.Id == _registroAtualizado.Id);

                var _registroSelecionado = await _repository.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Nome, _registroSelecionado.Nome);
                Assert.Equal(_registroAtualizado.CodIBGE, _registroSelecionado.CodIBGE);
                Assert.Equal(_registroAtualizado.UFId, _registroSelecionado.UFId);
                Assert.Null(_registroSelecionado.UF);

                _registroSelecionado = await _repository.GetCompletoByIBGE(_registroAtualizado.CodIBGE);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Nome, _registroSelecionado.Nome);
                Assert.Equal(_registroAtualizado.CodIBGE, _registroSelecionado.CodIBGE);
                Assert.Equal(_registroAtualizado.UFId, _registroSelecionado.UFId);
                Assert.NotNull(_registroSelecionado.UF);
                Assert.True(_registroSelecionado.UF.Id != Guid.Empty);

                _registroSelecionado = await _repository.GetCompletoById(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Nome, _registroSelecionado.Nome);
                Assert.Equal(_registroAtualizado.CodIBGE, _registroSelecionado.CodIBGE);
                Assert.Equal(_registroAtualizado.UFId, _registroSelecionado.UFId);
                Assert.NotNull(_registroSelecionado.UF);
                Assert.True(_registroSelecionado.UF.Id != Guid.Empty);

                var _todosRegistros = await _repository.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 0);

                var _removeu = await _repository.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);

                var _registroDeletado = await _repository.SelectAsync(_registroSelecionado.Id);
                Assert.Null(_registroDeletado);
            }
        }
    }
}
