using Autenticacao.DTO;
using Autenticacao.Models;
using AutoMapper;

namespace Autenticacao.Profiles
{
    public class PerfilProfile : Profile
    {
        public PerfilProfile()
        {
            CreateMap<CriaPerfilDTO, Perfil>();
            CreateMap<Perfil, CriaPerfilDTO>();
        }
    }
}
