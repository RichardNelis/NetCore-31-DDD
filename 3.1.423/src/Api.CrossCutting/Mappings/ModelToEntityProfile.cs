using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            UserMapper();
            UFMapper();
            MunicipioMapper();
            CEPMapper();
        }

        private void CEPMapper()
        {
            CreateMap<CEPModel, CEPEntity>()
                .ReverseMap();
        }

        private void MunicipioMapper()
        {
            CreateMap<MunicipioModel, MunicipioEntity>()
                .ReverseMap();
        }

        private void UFMapper()
        {
            CreateMap<UFModel, UFEntity>()
                .ReverseMap();
        }

        private void UserMapper()
        {
            CreateMap<UserModel, UserEntity>()
                .ReverseMap();
        }
    }
}
