using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.UF;
using Api.Domain.Interfaces.Services.UF;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class UFService : IUFService
    {
        private IUFRepository _repository;
        private readonly IMapper _mapper;

        public UFService(IUFRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UFDTO> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UFDTO>(entity);
        }

        public async Task<IEnumerable<UFDTO>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UFDTO>>(entities);
        }
    }
}
