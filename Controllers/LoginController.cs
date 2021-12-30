using Autenticacao.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        /*[HttpPost]
        public IActionResult Login(LoginDTO login)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
            if (usuario == null)
                return NotFound();
            return CreatedAtAction(nameof(BuscaUsuarioPorId), new { Id = usuario.Id }, usuario);
        }*/
    }
}
