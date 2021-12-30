using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticacao.Models
{
    public class UsuarioPerfil
    {
        public Guid UsuarioId { get; set; }
        public int PerfilId { get; set; }
        public Usuario Usuario { get; set; }
        public Perfil Perfil { get; set; }
    }
}
