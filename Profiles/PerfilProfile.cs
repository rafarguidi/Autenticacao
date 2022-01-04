using Autenticacao.DTO.Perfil;
using Autenticacao.Models;
using AutoMapper;

namespace Autenticacao.Profiles
{
    public class PerfilProfile : Profile
    {
        public PerfilProfile()
        {
            CreateMap<CriaPerfilDTO, Perfil>();
            CreateMap<Perfil, ExibePerfilDTO>();
            CreateMap<Perfil, ExibePerfilListaDTO>();
            CreateMap<Perfil, PerfilAdicionadoDTO>();
        }
    }
}
