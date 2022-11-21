using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UFImplementation : BaseRepository<UFEntity>, IUFRepository
    {
        private DbSet<UFEntity> _dataset;

        public UFImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UFEntity>();
        }


    }
}
