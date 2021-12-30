using Autenticacao.Data;
using Autenticacao.DTO;
using Autenticacao.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Autenticacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioContext _context;

        public UsuarioController(UsuarioContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaUsuario([FromBody] UsuarioDTO usuario)
        {
            var user = new Usuario()
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now,
                DataUltimoLogin = DateTime.Now
            };

            _context.Usuarios.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaUsuarioPorId), new { Id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaUsuarioPorId(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
                return Ok(usuario);
            return NotFound();
        }

        [HttpGet]
        public IEnumerable<Usuario> BuscaUsuarios()
        {
            return _context.Usuarios;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
            if (usuario == null)
                return NotFound();
            return CreatedAtAction(nameof(BuscaUsuarioPorId), new { Id = usuario.Id }, usuario);
        }

    }
}
