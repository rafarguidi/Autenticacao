using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autenticacao.DTO
{
    public class CriaUsuarioDTO
    {
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail informado não é válido")]
        [Required]
        public string Email { get; set; }
        public string Senha { get; set; }
        public IList<CriaPerfilDTO> Perfis { get; set; }
    }
}
