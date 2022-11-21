using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class MunicipioEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        public int CodIBGE { get; set; }

        [Required]
        public Guid UFId { get; set; }

        public UFEntity UF { get; set; }

        public IEnumerable<CEPEntity> CEPs { get; set; }
    }
}
