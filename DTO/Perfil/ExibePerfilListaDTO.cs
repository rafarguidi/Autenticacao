using System.ComponentModel.DataAnnotations;

namespace Autenticacao.DTO.Perfil
{
    public class ExibePerfilListaDTO
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
