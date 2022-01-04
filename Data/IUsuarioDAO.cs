using Autenticacao.DTO.Usuario;
using Autenticacao.Models;
using System;
using System.Collections.Generic;

namespace Autenticacao.Data
{
    public interface IUsuarioDAO
    {
        void Adicionar(Usuario u);
        IEnumerable<Usuario> Usuarios();
        Usuario BuscarPorId(Guid id);
        Usuario Logar(LoginDTO login);
    }
}
