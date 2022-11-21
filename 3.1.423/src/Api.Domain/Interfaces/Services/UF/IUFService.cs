using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.UF;

namespace Api.Domain.Interfaces.Services.UF
{
    public interface IUFService
    {
        Task<UFDTO> Get(Guid id);

        Task<IEnumerable<UFDTO>> GetAll();
    }
}
