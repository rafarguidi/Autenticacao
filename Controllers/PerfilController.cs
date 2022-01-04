using Autenticacao.Data;
using Autenticacao.DTO.Perfil;
using Autenticacao.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            var perfilDto = _mapper.Map<PerfilAdicionadoDTO>(perfil);

            return CreatedAtAction(nameof(BuscaPerfilPorId), new { Id = perfil.Id }, perfilDto);
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
        public IEnumerable<ExibePerfilListaDTO> BuscaPerfis()
        {
            var listaPerfis = _dao.Perfis();
            var listaDto = _mapper.Map<IEnumerable<ExibePerfilListaDTO>>(listaPerfis);
            return listaDto;
        }
    }
}
