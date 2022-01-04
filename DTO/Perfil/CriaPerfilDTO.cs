using System.ComponentModel.DataAnnotations;

namespace Autenticacao.DTO.Perfil
{
    public class CriaPerfilDTO
    {
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 4)]
        public string Nome { get; set; }
    }
}
