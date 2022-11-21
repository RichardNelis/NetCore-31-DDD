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
    public class CEPCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public CEPCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD do CEP")]
        [Trait("CRUD", "CEPEntity")]
        public async Task E_Possivel_Realizar_CRUD_CEPAsync()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                MunicipioImplementation _repositoryMunicipio = new MunicipioImplementation(context);
                MunicipioEntity _entityMunicipio = new MunicipioEntity()
                {
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                    UFId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                };

                var _municipioRegistroCriado = await _repositoryMunicipio.InsertAsync(_entityMunicipio);
                Assert.NotNull(_municipioRegistroCriado);
                Assert.Equal(_entityMunicipio.Nome, _municipioRegistroCriado.Nome);
                Assert.Equal(_entityMunicipio.CodIBGE, _municipioRegistroCriado.CodIBGE);
                Assert.Equal(_entityMunicipio.UFId, _municipioRegistroCriado.UFId);
                Assert.False(_entityMunicipio.Id == Guid.Empty);

                CEPImplementation _repository = new CEPImplementation(context);
                CEPEntity _entity = new CEPEntity()
                {
                    CEP = "13.876-591",
                    Logradouro = Faker.Address.StreetAddress(),
                    Numero = "123",
                    MunicipioId = _municipioRegistroCriado.Id
                };

                var _registroCriado = await _repository.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.CEP, _registroCriado.CEP);
                Assert.Equal(_entity.Logradouro, _registroCriado.Logradouro);
                Assert.Equal(_entity.Numero, _registroCriado.Numero);
                Assert.Equal(_entity.MunicipioId, _registroCriado.MunicipioId);
                Assert.False(_entity.Id == Guid.Empty);

                _entity.Logradouro = Faker.Address.StreetAddress();
                _entity.Id = _registroCriado.Id;
                var _registroAtualizado = await _repository.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.CEP, _registroAtualizado.CEP);
                Assert.Equal(_entity.Logradouro, _registroAtualizado.Logradouro);
                Assert.Equal(_entity.Numero, _registroAtualizado.Numero);
                Assert.Equal(_entity.MunicipioId, _registroAtualizado.MunicipioId);
                Assert.Equal(_entity.Id, _registroAtualizado.Id);

                var _registroExiste = await _repository.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repository.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.CEP, _registroSelecionado.CEP);
                Assert.Equal(_registroAtualizado.Logradouro, _registroSelecionado.Logradouro);
                Assert.Equal(_registroAtualizado.Numero, _registroSelecionado.Numero);
                Assert.Equal(_registroAtualizado.MunicipioId, _registroSelecionado.MunicipioId);
                Assert.Equal(_registroAtualizado.Id, _registroSelecionado.Id);

                _registroSelecionado = await _repository.SelectAsync(_registroAtualizado.CEP);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.CEP, _registroSelecionado.CEP);
                Assert.Equal(_registroAtualizado.Logradouro, _registroSelecionado.Logradouro);
                Assert.Equal(_registroAtualizado.Numero, _registroSelecionado.Numero);
                Assert.Equal(_registroAtualizado.MunicipioId, _registroSelecionado.MunicipioId);
                Assert.Equal(_registroAtualizado.Id, _registroSelecionado.Id);
                Assert.NotNull(_registroSelecionado.Municipio);
                Assert.True(_registroSelecionado.Municipio.Id != Guid.Empty);
                Assert.Equal(_municipioRegistroCriado.Nome, _registroSelecionado.Municipio.Nome);
                Assert.NotNull(_registroSelecionado.Municipio.UF);
                Assert.True(_registroSelecionado.Municipio.UF.Id != Guid.Empty);
                Assert.Equal("SP", _registroSelecionado.Municipio.UF.Sigla);

                var _todosRegistros = await _repository.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 0);

                var _removeu = await _repository.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);

                _registroSelecionado = await _repository.SelectAsync(_registroAtualizado.Id);
                Assert.Null(_registroSelecionado);
            }
        }
    }
}
