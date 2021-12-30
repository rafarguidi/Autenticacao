using Autenticacao.Models;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao.Data
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public UsuarioContext(DbContextOptions<UsuarioContext> opt) : base(opt)
        {

        }
    }
}
