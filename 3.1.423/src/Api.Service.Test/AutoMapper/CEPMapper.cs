using System;
using Api.Domain.Models;
using Xunit;
using System.Collections.Generic;
using Api.Domain.Entities;
using System.Linq;
using Api.Domain.Dtos.CEP;

namespace Api.Service.Test.AutoMapper
{
    public class CEPMapper : BaseTesteService
    {
        [Fact(DisplayName = "É possível Mapear os Modelos de CEP")]
        public void E_Possivel_Mapear_Os_Modelos_CEP()
        {
            var cepModel = new CEPModel()
            {
                Id = Guid.NewGuid(),
                CEP = Faker.RandomNumber.Next(100000, 999999).ToString(),
                Logradouro = Faker.Address.StreetName(),
                Numero = "",
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                MunicipioId = Guid.NewGuid(),
            };

            var listaEntity = new List<CEPEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new CEPEntity()
                {
                    Id = Guid.NewGuid(),
                    CEP = Faker.RandomNumber.Next(100000, 999999).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = Faker.RandomNumber.Next(100000, 999999).ToString(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioEntity()
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                        UFId = Guid.NewGuid(),
                        UF = new UFEntity()
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 3),
                        }
                    }
                };

                listaEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<CEPEntity>(cepModel);
            Assert.Equal(entity.Id, cepModel.Id);
            Assert.Equal(entity.Logradouro, cepModel.Logradouro);
            Assert.Equal(entity.Numero, cepModel.Numero);
            Assert.Equal(entity.CEP, cepModel.CEP);
            Assert.Equal(entity.CreateAt, cepModel.CreateAt);
            Assert.Equal(entity.UpdateAt, cepModel.UpdateAt);

            //Entity => DTO
            var dto = Mapper.Map<CEPDTO>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.Logradouro, entity.Logradouro);
            Assert.Equal(dto.Numero, entity.Numero);
            Assert.Equal(dto.CEP, entity.CEP);

            //Entity => DTO
            var dtoCompleto = Mapper.Map<CEPDTO>(listaEntity.First());
            Assert.Equal(dtoCompleto.Id, listaEntity.First().Id);
            Assert.Equal(dtoCompleto.Logradouro, listaEntity.First().Logradouro);
            Assert.Equal(dtoCompleto.Numero, listaEntity.First().Numero);
            Assert.Equal(dtoCompleto.CEP, listaEntity.First().CEP);
            Assert.NotNull(dtoCompleto.Municipio);
            Assert.True(dtoCompleto.Municipio.Id != Guid.Empty);
            Assert.NotNull(dtoCompleto.Municipio.UF);
            Assert.True(dtoCompleto.Municipio.UF.Id != Guid.Empty);

            var listDTO = Mapper.Map<List<CEPDTO>>(listaEntity);
            Assert.True(listDTO.Count() == listaEntity.Count());

            for (int i = 0; i < listDTO.Count(); i++)
            {
                Assert.Equal(listDTO[i].Id, listaEntity[i].Id);
                Assert.Equal(listDTO[i].Logradouro, listaEntity[i].Logradouro);
                Assert.Equal(listDTO[i].Numero, listaEntity[i].Numero);
                Assert.Equal(listDTO[i].CEP, listaEntity[i].CEP);
            }

            var dtoCreateResult = Mapper.Map<CEPDTOCreateResult>(entity);
            Assert.Equal(dtoCreateResult.Id, entity.Id);
            Assert.Equal(dtoCreateResult.CEP, entity.CEP);
            Assert.Equal(dtoCreateResult.Logradouro, entity.Logradouro);
            Assert.Equal(dtoCreateResult.Numero, entity.Numero);
            Assert.Equal(dtoCreateResult.CreateAt, entity.CreateAt);

            var dtoUpdateResult = Mapper.Map<CEPDTOUpdateResult>(entity);
            Assert.Equal(dtoUpdateResult.Id, entity.Id);
            Assert.Equal(dtoUpdateResult.CEP, entity.CEP);
            Assert.Equal(dtoUpdateResult.Logradouro, entity.Logradouro);
            Assert.Equal(dtoUpdateResult.Numero, entity.Numero);
            Assert.Equal(dtoUpdateResult.UpdateAt, entity.UpdateAt);

            //DTO => Model
            dto.Numero = "";
            var dtoCreate = Mapper.Map<CEPModel>(dto);
            Assert.Equal(dtoCreate.Id, dto.Id);
            Assert.Equal(dtoCreate.CEP, dto.CEP);
            Assert.Equal(dtoCreate.Logradouro, dto.Logradouro);
            Assert.Equal("S/N", dtoCreate.Numero);

            //DTO => Model
            dto.Numero = "";
            var dtoUpdate = Mapper.Map<CEPModel>(dto);
            Assert.Equal(dtoUpdate.Id, dto.Id);
            Assert.Equal(dtoUpdate.CEP, dto.CEP);
            Assert.Equal(dtoUpdate.Logradouro, dto.Logradouro);
            Assert.Equal("S/N", dtoUpdate.Numero);
        }
    }
}
