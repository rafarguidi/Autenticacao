using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autenticacao.Models
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<UsuarioPerfil> Usuarios { get; set; }
    }
}