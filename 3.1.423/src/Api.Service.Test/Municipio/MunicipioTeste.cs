using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.UF;

namespace Api.Service.Test.Municipio
{
    public class MunicipioTeste
    {
        public static string NomeMunicipio { get; set; }

        public static int CodigoIBGE { get; set; }

        public static string NomeMunicipioAlterado { get; set; }

        public static int CodigoIBGEAlterado { get; set; }

        public static Guid IdMunicipio { get; set; }

        public static Guid UFId { get; set; }

        public List<MunicipioDTO> municipioDTOs { get; set; }

        public MunicipioDTO municipioDTO { get; set; }

        public MunicipioDTOCompleto municipioDTOCompleto { get; set; }

        public MunicipioDTOCreate municipioDTOCreate { get; set; }

        public MunicipioDTOCreateResult municipioDTOCreateResult { get; set; }

        public MunicipioDTOUpdate municipioDTOUpdate { get; set; }

        public MunicipioDTOUpdateResult municipioDTOUpdateResult { get; set; }

        public MunicipioTeste()
        {
            IdMunicipio = Guid.NewGuid();
            NomeMunicipio = Faker.Address.City();
            CodigoIBGE = Faker.RandomNumber.Next(100000, 999999);
            NomeMunicipioAlterado = Faker.Address.City();
            CodigoIBGEAlterado = Faker.RandomNumber.Next(100000, 999999);
            UFId = Guid.NewGuid();

            municipioDTOs = new List<MunicipioDTO>();

            for (int i = 0; i < 10; i++)
            {
                var dto = new MunicipioDTO()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                    UFId = Guid.NewGuid(),
                };

                municipioDTOs.Add(dto);
            }

            municipioDTO = new MunicipioDTO()
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGE,
                UFId = UFId,
            };

            municipioDTOCompleto = new MunicipioDTOCompleto()
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGE,
                UFId = UFId,
                UF = new UFDTO()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                }
            };

            municipioDTOCreate = new MunicipioDTOCreate()
            {
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGE,
                UFId = UFId,
            };

            municipioDTOCreateResult = new MunicipioDTOCreateResult()
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGE,
                UFId = UFId,
                CreateAt = DateTime.UtcNow
            };

            municipioDTOUpdate = new MunicipioDTOUpdate()
            {
                Id = IdMunicipio,
                Nome = NomeMunicipioAlterado,
                CodIBGE = CodigoIBGEAlterado,
                UFId = UFId,
            };

            municipioDTOUpdateResult = new MunicipioDTOUpdateResult()
            {
                Id = IdMunicipio,
                Nome = NomeMunicipioAlterado,
                CodIBGE = CodigoIBGEAlterado,
                UFId = UFId,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}
