using System;

namespace Autenticacao.DTO
{
    public class ExibeUsuarioListaDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataUltimoLogin { get; set; }
    }
}
