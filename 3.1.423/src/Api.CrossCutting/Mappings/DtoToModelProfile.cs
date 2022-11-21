using Api.Domain.Dtos.CEP;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.UF;
using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            UserMapper();

            UFMapper();

            MunicipioMapper();

            CEPMapper();
        }

        private void UserMapper()
        {
            CreateMap<UserModel, UserDto>()
                .ReverseMap();

            CreateMap<UserModel, UserDtoCreate>()
                .ReverseMap();

            CreateMap<UserModel, UserDtoUpdate>()
                .ReverseMap();
        }

        private void UFMapper()
        {
            CreateMap<UFModel, UFDTO>()
                .ReverseMap();
        }

        private void MunicipioMapper()
        {
            CreateMap<MunicipioModel, MunicipioDTO>()
                .ReverseMap();

            CreateMap<MunicipioModel, MunicipioDTOCreate>()
                .ReverseMap();

            CreateMap<MunicipioModel, MunicipioDTOUpdate>()
                .ReverseMap();
        }

        private void CEPMapper()
        {
            CreateMap<CEPModel, CEPDTO>()
                .ReverseMap();

            CreateMap<CEPModel, CEPDTOCreate>()
                .ReverseMap();

            CreateMap<CEPModel, CEPDTOUpdate>()
                .ReverseMap();
        }
    }
}
