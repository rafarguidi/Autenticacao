using Autenticacao.Models;
using System.Collections.Generic;

namespace Autenticacao.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public IList<Perfil> Perfis { get; set; }
    }
}
