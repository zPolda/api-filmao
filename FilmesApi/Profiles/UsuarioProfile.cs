using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();

            CreateMap<Usuario, ReadUsuarioDto>();

            CreateMap<UpdateUsuarioDto, Usuario>();

            CreateMap<Usuario, UpdateUsuarioDto>();
        }
    }
}
