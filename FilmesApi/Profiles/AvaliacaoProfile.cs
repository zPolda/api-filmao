using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class AvaliacaoProfile : Profile
    {
        public AvaliacaoProfile() 
        {
            CreateMap<CreateAvaliacaoDto, Avaliacao>();
            CreateMap<Avaliacao, ReadAvaliacaoDto>()
                .ForMember(dest => dest.NomeFilme, opt => opt.MapFrom(src => src.Filme.Titulo))
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario.Nome));
            CreateMap<UpdateAvaliacaoDto, Avaliacao>();
            CreateMap<Avaliacao, UpdateAvaliacaoDto>();
        }
    }
}
