using System;
using Api.Domain.Dtos.UF;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDTOUpdateResult
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public int CodIBGE { get; set; }

        public DateTime UpdateAt { get; set; }

        public Guid UFId { get; set; }
    }
}
