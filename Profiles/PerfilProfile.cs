using Autenticacao.DTO;
using Autenticacao.Models;
using AutoMapper;
using System.Collections.Generic;

namespace Autenticacao.Profiles
{
    public class PerfilProfile : Profile
    {
        public PerfilProfile()
        {
            CreateMap<CriaPerfilDTO, Perfil>();
            CreateMap<Perfil, ExibePerfilDTO>();
        }
    }
}
