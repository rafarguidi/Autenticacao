using Autenticacao.DTO.Usuario;
using Autenticacao.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Autenticacao.Data.EfCore
{
    public class UsuarioDAOEntity : IUsuarioDAO, IDisposable
    {
        private AutenticacaoContext context;

        public UsuarioDAOEntity()
        {
            context = new AutenticacaoContext();
        }
        public void Adicionar(Usuario u)
        {
            context.Usuarios.Add(u);
            context.SaveChanges();
        }

        public Usuario BuscarPorId(Guid id)
        {
            var usuario = context.Usuarios
                .Include(u => u.Perfis)
                .ThenInclude(up => up.Perfil)
                .FirstOrDefault(u => u.Id == id);

            return usuario;
        }

        public IEnumerable<Usuario> Usuarios()
        {
            return context.Usuarios
                .ToList();
        }

        public Usuario Logar(LoginDTO login)
        {
            var usuario = context.Usuarios
                .Include(u => u.Perfis)
                .ThenInclude(up => up.Perfil)
                .FirstOrDefault(u => u.Email == login.Email);
            
            if (usuario == null || usuario?.Senha != login.Senha)
                return null;
            usuario.DataUltimoLogin = DateTime.Now;
            context.SaveChanges();
            return usuario;
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
