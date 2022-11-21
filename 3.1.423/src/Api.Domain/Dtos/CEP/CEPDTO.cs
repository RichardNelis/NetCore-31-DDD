using System;
using Api.Domain.Dtos.Municipio;

namespace Api.Domain.Dtos.CEP
{
    public class CEPDTO
    {
        public Guid Id { get; set; }

        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public Guid MunicipioId { get; set; }

        public MunicipioDTOCompleto Municipio { get; set; }
    }
}
