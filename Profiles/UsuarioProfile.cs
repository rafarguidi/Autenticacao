using Autenticacao.DTO;
using Autenticacao.Models;
using AutoMapper;

namespace Autenticacao.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CriaUsuarioDTO, Usuario>();
            CreateMap<Usuario, ExibeUsuarioDTO>();
        }
    }
}
