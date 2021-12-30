using Autenticacao.Models;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao.Data
{
    public class PerfilContext : DbContext
    {
        public DbSet<Perfil> Perfis { get; set; }

        public PerfilContext(DbContextOptions<PerfilContext> opt) : base(opt)
        {

        }
    }
}
