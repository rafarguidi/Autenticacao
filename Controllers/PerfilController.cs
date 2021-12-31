using Autenticacao.Data;
using Autenticacao.Data.EfCore;
using Autenticacao.DTO;
using Autenticacao.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Autenticacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilController : ControllerBase
    {
        private IPerfilDAO _dao;
        private IMapper _mapper;

        public PerfilController(IMapper mapper, IPerfilDAO dao)
        {
            _mapper = mapper;
            _dao = dao;
        }

        [HttpPost]
        public IActionResult AdicionaPerfil([FromBody] CriaPerfilDTO novoPerfil)
        {
            var perfil = _mapper.Map<Perfil>(novoPerfil);

            _dao.Adicionar(perfil);

            return CreatedAtAction(nameof(BuscaPerfilPorId), new { Id = perfil.Id }, perfil);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaPerfilPorId(int id)
        {
            var perfil = _dao.BuscarPorId(id);
            if (perfil != null)
            {
                var exibeDto = _mapper.Map<ExibePerfilDTO>(perfil);
                return Ok(exibeDto);
            }
            return NotFound();
        }

        [HttpGet]
        public IEnumerable<Perfil> BuscaPerfis()
        {
            return _dao.Perfis();
        }
    }
}
