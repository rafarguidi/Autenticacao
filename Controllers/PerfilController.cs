using Autenticacao.Data;
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
        private PerfilContext _context;
        private IMapper _mapper;

        public PerfilController(PerfilContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaPerfil([FromBody] CriaPerfilDTO novoPerfil)
        {
            var perfil = _mapper.Map<Perfil>(novoPerfil);

            _context.Perfis.Add(perfil);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscaPerfilPorId), new { Id = perfil.Id }, perfil);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaPerfilPorId(int id)
        {
            var perfil = _context.Perfis.FirstOrDefault(p => p.Id == id);
            if (perfil != null)
                return Ok(perfil);
            return NotFound();
        }

        [HttpGet]
        public IEnumerable<Perfil> BuscaPerfis()
        {
            return _context.Perfis;
        }
    }
}
