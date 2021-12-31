using Autenticacao.Models;
using System.Collections.Generic;

namespace Autenticacao.Data
{
    public interface IPerfilDAO
    {
        void Adicionar(Perfil p);
        IEnumerable<Perfil> Perfis();
        Perfil BuscarPorId(int id);
    }
}
