using Autenticacao.Data;
using Autenticacao.Data.EfCore;
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
        private IUsuarioDAO _dao;
        private IMapper _mapper;

        public UsuarioController(IMapper mapper, IUsuarioDAO dao)
        {
            _mapper = mapper;
            _dao = dao;
        }

        [HttpPost]
        public IActionResult AdicionaUsuario([FromBody] CriaUsuarioDTO usuarioDto)
        {
            var user = _mapper.Map<Usuario>(usuarioDto);
            user.DataCriacao = DateTime.Now;
            user.DataAtualizacao = DateTime.Now;
            user.DataUltimoLogin = DateTime.Now;
            
            _dao.Adicionar(user);
            
            var exibeUsuarioDto = _mapper.Map<ExibeUsuarioDTO>(user);
            return CreatedAtAction(nameof(BuscaUsuarioPorId), new { Id = user.Id }, exibeUsuarioDto);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaUsuarioPorId(Guid id)
        {
            var usuario = _dao.BuscarPorId(id);
            
            if (usuario != null)
            {
                var usuarioDto = _mapper.Map<ExibeUsuarioDTO>(usuario);
                return Ok(usuarioDto);
            }
            return NotFound();
        }

        [HttpGet]
        public IEnumerable<ExibeUsuarioListaDTO> BuscaUsuarios()
        {
            var usuarios = _dao.Usuarios();
            var usuariosDto = _mapper.Map<IEnumerable<ExibeUsuarioListaDTO>>(usuarios);
            return usuariosDto;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            Usuario usuario = _dao.Logar(login);
            if (usuario == null)
                return NotFound();
            var usuarioDto = _mapper.Map<ExibeUsuarioDTO>(usuario);
            return CreatedAtAction(nameof(BuscaUsuarioPorId), new { Id = usuario.Id }, usuarioDto);
        }

    }
}
