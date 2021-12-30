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
        public IActionResult AdicionaUsuario([FromBody] UsuarioDTO usuario)
        {
            var user = new Usuario()
            {
                Id = id++,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now,
                DataUltimoLogin = DateTime.Now
            };

            usuarios.Add(user);
            
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
        public IActionResult BuscaUsuarios()
        {
            return Ok(usuarios);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
            if (usuario == null)
                return NotFound();
            return CreatedAtAction(nameof(BuscaUsuarioPorId), new { Id = usuario.Id }, usuario);
        }

    }
}
