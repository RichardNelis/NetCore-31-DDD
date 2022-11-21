using System;
using System.Collections.Generic;
using Api.Domain.Dtos.CEP;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.UF;

namespace Api.Service.Test.CEP
{
    public class CEPTeste
    {
        public static string CEPOriginal { get; set; }

        public static string LogradouroOriginal { get; set; }

        public static string NumeroOriginal { get; set; }

        public static string CEPAlterado { get; set; }

        public static string LogradouroAlterado { get; set; }

        public static string NumeroAlterado { get; set; }

        public static Guid IdMunicipio { get; set; }

        public static Guid IdCEP { get; set; }

        public List<CEPDTO> cepDTOs { get; set; }

        public CEPDTO cepDTO { get; set; }

        public CEPDTOCreate cepDTOCreate { get; set; }

        public CEPDTOCreateResult cepDTOCreateResult { get; set; }

        public CEPDTOUpdate cepDTOUpdate { get; set; }

        public CEPDTOUpdateResult cepDTOUpdateResult { get; set; }

        public CEPTeste()
        {
            IdMunicipio = Guid.NewGuid();
            IdCEP = Guid.NewGuid();
            CEPOriginal = Faker.RandomNumber.Next(100000, 999999).ToString();
            NumeroOriginal = Faker.RandomNumber.Next(100000, 999999).ToString();
            LogradouroOriginal = Faker.Address.StreetAddress();
            CEPAlterado = Faker.RandomNumber.Next(100000, 999999).ToString();
            NumeroAlterado = Faker.RandomNumber.Next(100000, 999999).ToString();
            LogradouroAlterado = Faker.Address.StreetAddress();

            cepDTOs = new List<CEPDTO>();

            for (int i = 0; i < 10; i++)
            {
                var dto = new CEPDTO()
                {
                    Id = Guid.NewGuid(),
                    CEP = Faker.RandomNumber.Next(100000, 999999).ToString(),
                    Logradouro = Faker.Address.StreetAddress(),
                    Numero = Faker.RandomNumber.Next(100000, 999999).ToString(),
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioDTOCompleto()
                    {
                        Id = IdMunicipio,
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                        UFId = Guid.NewGuid(),
                        UF = new UFDTO()
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 3),
                        }
                    }
                };

                cepDTOs.Add(dto);
            }

            cepDTO = new CEPDTO()
            {
                Id = IdCEP,
                CEP = CEPOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
                Municipio = new MunicipioDTOCompleto()
                {
                    Id = IdMunicipio,
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                    UFId = Guid.NewGuid(),
                    UF = new UFDTO()
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3),
                    }
                }
            };

            cepDTOCreate = new CEPDTOCreate()
            {
                CEP = CEPOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
            };

            cepDTOCreateResult = new CEPDTOCreateResult()
            {
                Id = IdCEP,
                CEP = CEPOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
                CreateAt = DateTime.UtcNow,
            };

            cepDTOUpdate = new CEPDTOUpdate()
            {
                Id = IdCEP,
                CEP = CEPAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = IdMunicipio,
            };

            cepDTOUpdateResult = new CEPDTOUpdateResult()
            {
                Id = IdCEP,
                CEP = CEPAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = IdMunicipio,
                UpdateAt = DateTime.UtcNow,
            };
        }
    }
}
