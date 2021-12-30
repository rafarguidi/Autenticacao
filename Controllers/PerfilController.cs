using Autenticacao.DTO;
using Autenticacao.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Autenticacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilController : ControllerBase
    {
        private static IList<Perfil> perfis = new List<Perfil>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaPerfil([FromBody] PerfilDTO novoPerfil)
        {
            var perfil = new Perfil()
            {
                Id = id++,
                Nome = novoPerfil.Perfil
            };

            perfis.Add(perfil);

            return CreatedAtAction(nameof(BuscaPerfilPorId), new { Id = perfil.Id }, perfil);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaPerfilPorId(int id)
        {
            var perfil = perfis.FirstOrDefault(p => p.Id == id);
            if (perfil != null)
                return Ok(perfil);
            return NotFound();
        }

        [HttpGet]
        public IActionResult BuscaPerfis()
        {
            return Ok(perfis);
        }
    }
}
