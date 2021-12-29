using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autenticacao.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public IList<Perfil> Perfis { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
