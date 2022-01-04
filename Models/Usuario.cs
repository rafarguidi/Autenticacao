using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autenticacao.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail informado não é válido")]
        [Required]
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public List<UsuarioPerfil> Perfis { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataUltimoLogin { get; set; }
    }
}
