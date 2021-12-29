using Autenticacao.DTO;
using Autenticacao.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static IList<Usuario> usuarios = new List<Usuario>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionarUsuario([FromBody] UsuarioDTO usuario)
        {
            var user = new Usuario()
            {
                Id = id++,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };
            
            return CreatedAtAction(nameof(BuscaUsuarioPorId), new { Id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaUsuarioPorId(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
                return Ok(usuario);
            return NotFound();
        }

        [HttpGet]
        public IActionResult BuscaUsuario()
        {
            return Ok(usuarios);
        }

    }
}
