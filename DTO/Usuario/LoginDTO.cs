using System.ComponentModel.DataAnnotations;

namespace Autenticacao.DTO.Usuario
{
    public class LoginDTO
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail informado não é válido")]
        [Required]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
