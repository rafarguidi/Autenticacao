using Autenticacao.DTO.Perfil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autenticacao.DTO.Usuario
{
    public class ExibeUsuarioDTO
    {
        public Guid Id { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail informado não é válido")]
        [Required]
        public string Email { get; set; }
        public string Nome { get; set; }
        public IList<ExibePerfilDTO> Perfis { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataUltimoLogin { get; set; }
    }
}
