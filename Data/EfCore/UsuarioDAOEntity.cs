using Autenticacao.Models;
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
            return context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> Usuarios()
        {
            return context.Usuarios.ToList();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
