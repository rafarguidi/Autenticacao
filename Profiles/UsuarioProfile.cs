using Autenticacao.DTO;
using Autenticacao.Models;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Autenticacao.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CriaUsuarioDTO, Usuario>();
            CreateMap<Usuario, ExibeUsuarioDTO>();

            CreateMap<CriaPerfilDTO, UsuarioPerfil>()
                .AfterMap(
                    (dto, u) => { u.Perfil = new Perfil() { Nome = dto.Nome }; }
                );

            CreateMap<UsuarioPerfil, ExibePerfilDTO>()
                .AfterMap(
                    (up, dto) => { dto.Nome = up.Perfil.Nome; }
                );

        }
    }
}
