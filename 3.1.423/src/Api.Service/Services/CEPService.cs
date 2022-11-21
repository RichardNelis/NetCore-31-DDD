using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.CEP;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.CEP;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class CEPService : ICEPService
    {
        private ICEPRepository _repository;
        private readonly IMapper _mapper;

        public CEPService(ICEPRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CEPDTO> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CEPDTO>(entity);
        }

        public async Task<CEPDTO> Get(string cep)
        {
            var entity = await _repository.SelectAsync(cep);
            return _mapper.Map<CEPDTO>(entity);
        }

        public async Task<IEnumerable<CEPDTO>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<CEPDTO>>(entities);
        }

        public async Task<CEPDTOCreateResult> Post(CEPDTOCreate CEP)
        {
            var model = _mapper.Map<CEPModel>(CEP);
            var entity = _mapper.Map<CEPEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CEPDTOCreateResult>(result);
        }

        public async Task<CEPDTOUpdateResult> Put(CEPDTOUpdate CEP)
        {
            var model = _mapper.Map<CEPModel>(CEP);
            var entity = _mapper.Map<CEPEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<CEPDTOUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
