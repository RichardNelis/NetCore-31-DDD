using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class MunicipioImplementation : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        private DbSet<MunicipioEntity> _dataset;

        public MunicipioImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<MunicipioEntity>();
        }

        public async Task<MunicipioEntity> GetCompletoByIBGE(int codIBGE)
        {
            return await _dataset.Include(x => x.UF).FirstOrDefaultAsync(x => x.CodIBGE.Equals(codIBGE));
        }

        public async Task<MunicipioEntity> GetCompletoById(Guid Id)
        {
            return await _dataset.Include(x => x.UF).FirstOrDefaultAsync(x => x.Id.Equals(Id));
        }        
    }
}
