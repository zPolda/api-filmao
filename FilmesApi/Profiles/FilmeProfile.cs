using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile() 
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, UpdateFilmeDto>();
            CreateMap<Filme, ReadFilmeDto>()
                .ForMember(filmeDto => filmeDto.Sessoes, opt => opt.MapFrom(filme => filme.Sessoes))
                .ForMember(filmeDto => filmeDto.Comentarios, opt => opt.MapFrom(filme => filme.Comentarios))
                .ForMember(filmeDto => filmeDto.Avaliacoes, opt => opt.MapFrom(filme => filme.Avaliacao));
        }
    }
}
