using System.Collections.Generic;
using System;
using Api.Domain.Models;
using Xunit;
using Api.Domain.Entities;
using Api.Domain.Dtos.UF;
using System.Linq;

namespace Api.Service.Test.AutoMapper
{
    public class UFMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelos de UF")]
        public void E_Possivel_Mapear_Os_Modelos_UF()
        {
            var model = new UFModel()
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.UsState(),
                Sigla = Faker.Address.UsState().Substring(1, 3),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };

            var entities = new List<UFEntity>();

            for (int i = 0; i < 5; i++)
            {
                var item = new UFEntity()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                };

                entities.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<UFEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.Sigla, model.Sigla);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity => DTO
            var dto = Mapper.Map<UFDTO>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.Nome, entity.Nome);
            Assert.Equal(dto.Sigla, entity.Sigla);

            var listaDTOs = Mapper.Map<List<UFDTO>>(entities);
            Assert.True(listaDTOs.Count() == entities.Count());

            for (int i = 0; i < listaDTOs.Count(); i++)
            {
                Assert.Equal(listaDTOs[i].Id, entities[i].Id);
                Assert.Equal(listaDTOs[i].Nome, entities[i].Nome);
                Assert.Equal(listaDTOs[i].Sigla, entities[i].Sigla);
            }

            //DTO => Model
            var modelToDTO = Mapper.Map<UFDTO>(model);
            Assert.Equal(modelToDTO.Id, model.Id);
            Assert.Equal(modelToDTO.Nome, model.Nome);
            Assert.Equal(modelToDTO.Sigla, model.Sigla);
        }
    }
}
