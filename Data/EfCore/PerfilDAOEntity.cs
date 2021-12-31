using Autenticacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticacao.Data.EfCore
{
    public class PerfilDAOEntity : IPerfilDAO, IDisposable
    {
        private AutenticacaoContext _context;

        public PerfilDAOEntity()
        {
            _context = new AutenticacaoContext();
        }
        public void Adicionar(Perfil p)
        {
            _context.Perfis.Add(p);
            _context.SaveChanges();
        }

        public Perfil BuscarPorId(int id)
        {
            return _context.Perfis.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Perfil> Perfis()
        {
            return _context.Perfis;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
