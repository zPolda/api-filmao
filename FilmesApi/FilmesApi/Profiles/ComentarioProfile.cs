using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class ComentarioProfile : Profile
    {
        public ComentarioProfile()
        {
            CreateMap<CreateComentarioDto, Comentario>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date ?? DateTime.Now));

            CreateMap<Comentario, ReadComentarioDto>()
                .ForMember(dest => dest.NomeFilme, opt => opt.MapFrom(src => src.Filme.Titulo)) 
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario.Nome));

            CreateMap<UpdateComentarioDto, Comentario>();
        }
    }
}
