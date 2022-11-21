using System;
namespace Api.Domain.Dtos.CEP
{
    public class CEPDTOCreateResult
    {
        public Guid Id { get; set; }

        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public Guid MunicipioId { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
