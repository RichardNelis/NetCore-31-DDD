using System;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDTOCreateResult
    {

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public int CodIBGE { get; set; }

        public DateTime CreateAt { get; set; }

        public Guid UFId { get; set; }
    }
}
