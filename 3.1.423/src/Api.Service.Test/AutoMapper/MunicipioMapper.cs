using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class MunicipioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É possível Mapear os Modelos de Município")]
        public void E_Possivel_Mapear_Os_Modelos_Municipio()
        {
            var municipioModel = new MunicipioModel()
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                UFId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };

            var listEntity = new List<MunicipioEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new MunicipioEntity()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                    UFId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    UF = new UFEntity()
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3),
                    }
                };

                listEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<MunicipioEntity>(municipioModel);
            Assert.Equal(entity.Id, municipioModel.Id);
            Assert.Equal(entity.Nome, municipioModel.Nome);
            Assert.Equal(entity.CodIBGE, municipioModel.CodIBGE);
            Assert.Equal(entity.UFId, municipioModel.UFId);
            Assert.Equal(entity.CreateAt, municipioModel.CreateAt);
            Assert.Equal(entity.UpdateAt, municipioModel.UpdateAt);

            //Entity => DTO
            var dto = Mapper.Map<MunicipioDTO>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.Nome, entity.Nome);
            Assert.Equal(dto.CodIBGE, entity.CodIBGE);
            Assert.Equal(dto.UFId, entity.UFId);

            var dtoCompleto = Mapper.Map<MunicipioDTOCompleto>(listEntity.First());
            Assert.Equal(dtoCompleto.Id, listEntity.First().Id);
            Assert.Equal(dtoCompleto.Nome, listEntity.First().Nome);
            Assert.Equal(dtoCompleto.CodIBGE, listEntity.First().CodIBGE);
            Assert.Equal(dtoCompleto.UFId, listEntity.First().UFId);
            Assert.NotNull(dtoCompleto.UF);
            Assert.True(dtoCompleto.UF.Id != Guid.Empty);

            var listDTO = Mapper.Map<List<MunicipioDTO>>(listEntity);
            Assert.True(listDTO.Count() == listEntity.Count());

            for (int i = 0; i < listDTO.Count(); i++)
            {
                Assert.Equal(listDTO[i].Id, listEntity[i].Id);
                Assert.Equal(listDTO[i].Nome, listEntity[i].Nome);
                Assert.Equal(listDTO[i].CodIBGE, listEntity[i].CodIBGE);
                Assert.Equal(listDTO[i].UFId, listEntity[i].UFId);
            }

            var dtoCreateResult = Mapper.Map<MunicipioDTOCreateResult>(entity);
            Assert.Equal(dtoCreateResult.Id, entity.Id);
            Assert.Equal(dtoCreateResult.Nome, entity.Nome);
            Assert.Equal(dtoCreateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(dtoCreateResult.UFId, entity.UFId);
            Assert.Equal(dtoCreateResult.CreateAt, entity.CreateAt);

            var dtoUpdateResult = Mapper.Map<MunicipioDTOUpdateResult>(entity);
            Assert.Equal(dtoUpdateResult.Id, entity.Id);
            Assert.Equal(dtoUpdateResult.Nome, entity.Nome);
            Assert.Equal(dtoUpdateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(dtoUpdateResult.UFId, entity.UFId);
            Assert.Equal(dtoUpdateResult.UpdateAt, entity.UpdateAt);

            //DTO => Model
            var model = Mapper.Map<MunicipioModel>(dto);
            Assert.Equal(dto.Id, model.Id);
            Assert.Equal(dto.Nome, model.Nome);
            Assert.Equal(dto.CodIBGE, model.CodIBGE);
            Assert.Equal(dto.UFId, model.UFId);

            var dtoCreate = Mapper.Map<MunicipioDTOCreate>(model);
            Assert.Equal(dtoCreate.Nome, model.Nome);
            Assert.Equal(dtoCreate.CodIBGE, model.CodIBGE);
            Assert.Equal(dtoCreate.UFId, model.UFId);

            var dtoUpdate = Mapper.Map<MunicipioDTOUpdate>(model);
            Assert.Equal(dtoUpdate.Id, model.Id);
            Assert.Equal(dtoUpdate.Nome, model.Nome);
            Assert.Equal(dtoUpdate.CodIBGE, model.CodIBGE);
            Assert.Equal(dtoUpdate.UFId, model.UFId);
        }
    }
}
