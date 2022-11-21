using Api.Domain.Dtos.CEP;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.UF;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            UserMapper();
            
            UFMapper();
            
            MunicipioMapper();

            CEPMapper();
        }

        private void UserMapper()
        {
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>()
               .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>()
               .ReverseMap();
        }

        private void UFMapper()
        {
            CreateMap<UFDTO, UFEntity>()
                .ReverseMap();
        }

        private void MunicipioMapper()
        {
            CreateMap<MunicipioDTO, MunicipioEntity>()
                .ReverseMap();

            CreateMap<MunicipioDTOCompleto, MunicipioEntity>()
                .ReverseMap();

            CreateMap<MunicipioDTOCreateResult, MunicipioEntity>()
               .ReverseMap();

            CreateMap<MunicipioDTOUpdateResult, MunicipioEntity>()
               .ReverseMap();
        }

        private void CEPMapper()
        {
            CreateMap<CEPDTO, CEPEntity>()
                .ReverseMap();

            CreateMap<CEPDTOCreateResult, CEPEntity>()
               .ReverseMap();

            CreateMap<CEPDTOUpdateResult, CEPEntity>()
               .ReverseMap();
        }
    }
}
