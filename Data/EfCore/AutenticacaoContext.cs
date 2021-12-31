using Autenticacao.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticacao.Data.EfCore
{
    public class AutenticacaoContext : DbContext
    {
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        /*public AutenticacaoContext(DbContextOptions<AutenticacaoContext> opt) : base(opt)
        {

        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioPerfil>().HasKey(up => new { up.UsuarioId, up.PerfilId });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host = localhost;database = postgres;user id= postgres; password = root2;");
        }
    }
}
