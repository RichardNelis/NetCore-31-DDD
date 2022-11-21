using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface ICEPRepository : IRepository<CEPEntity>
    {
        Task<CEPEntity> SelectAsync(string cep);
    }
}
