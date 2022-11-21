using System;
using System.Collections.Generic;
using Api.Domain.Dtos.UF;

namespace Api.Service.Test.UF
{
    public class UFTeste
    {
        public static string Nome { get; set; }
        public static string Sigla { get; set; }

        public static Guid Id { get; set; }

        public List<UFDTO> ListaUF { get; set; }

        public UFDTO UF { get; set; }

        public UFTeste()
        {
            ListaUF = new List<UFDTO>();

            Id = Guid.NewGuid();
            Sigla = Faker.Address.UsState().Substring(1, 3);
            Nome = Faker.Address.UsState();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UFDTO()
                {
                    Id = Guid.NewGuid(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                    Nome = Faker.Address.UsState(),
                };

                ListaUF.Add(dto);
            }

            UF = new UFDTO
            {
                Id = Id,
                Sigla = Sigla,
                Nome = Nome
            };
        }
    }
}
