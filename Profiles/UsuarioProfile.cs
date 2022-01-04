using Autenticacao.DTO.Perfil;
using Autenticacao.DTO.Usuario;
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
            CreateMap<Usuario, ExibeUsuarioListaDTO>();

            CreateMap<CriaPerfilDTO, UsuarioPerfil>()
                .AfterMap(
                    (dto, u) => { u.Perfil = new Perfil() { Nome = dto.Nome }; }
                );

            CreateMap<UsuarioPerfil, ExibePerfilDTO>()
                .AfterMap(
                    (up, dto) => { dto.Nome = up.Perfil?.Nome; }
                );

        }
    }
}
