using Autenticacao.Data;
using Autenticacao.DTO;
using Autenticacao.Models;
using AutoMapper;
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
        private IMapper _mapper;

        public UsuarioController(UsuarioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaUsuario([FromBody] CriaUsuarioDTO usuarioDto)
        {
            var user = _mapper.Map<Usuario>(usuarioDto);
            /*var user = new Usuario()
            {
                Id = Guid.NewGuid(),
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now,
                DataUltimoLogin = DateTime.Now
            };*/

            _context.Usuarios.Add(user);
            _context.SaveChanges();
            var exibeUsuarioDto = _mapper.Map<ExibeUsuarioDTO>(user);
            return CreatedAtAction(nameof(BuscaUsuarioPorId), new { Id = user.Id }, exibeUsuarioDto);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaUsuarioPorId(Guid id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                var usuarioDto = _mapper.Map<ExibeUsuarioDTO>(usuario);
                return Ok(usuarioDto);
            }
            return NotFound();
        }

        [HttpGet]
        public IEnumerable<ExibeUsuarioDTO> BuscaUsuarios()
        {
            var usuarios = _context.Usuarios;
            var usuariosDto = _mapper.Map<IEnumerable<ExibeUsuarioDTO>>(usuarios);
            return usuariosDto;
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
