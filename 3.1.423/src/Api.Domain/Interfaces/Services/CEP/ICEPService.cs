using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.CEP;

namespace Api.Domain.Interfaces.Services.CEP
{
    public interface ICEPService
    {
        Task<CEPDTO> Get(Guid id);

        Task<CEPDTO> Get(string cep);

        Task<CEPDTOCreateResult> Post(CEPDTOCreate cep);

        Task<CEPDTOUpdateResult> Put(CEPDTOUpdate cep);

        Task<bool> Delete(Guid id);
    }
}
