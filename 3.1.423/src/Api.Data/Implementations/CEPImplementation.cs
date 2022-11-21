using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CEPImplementation : BaseRepository<CEPEntity>, ICEPRepository
    {
        private DbSet<CEPEntity> _dataset;

        public CEPImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<CEPEntity>();
        }

        public async Task<CEPEntity> SelectAsync(string cep)
        {
            return await _dataset
                .Include(x => x.Municipio)
                .ThenInclude(x => x.UF)
                .FirstOrDefaultAsync(x => x.CEP.Equals(cep));
        }
    }
}
