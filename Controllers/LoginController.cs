using ImportSpedWeb.DTO;
using ImportSpedWeb.Models;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ImportSpedWeb.Interfaces;
using ImportSpedWeb.Custom;
using Microsoft.EntityFrameworkCore;
using ImportSpedWeb.Data;

namespace ImportSpedWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class LoginController : ControllerBase
    {

        private readonly ImportSpedContext _context;
        private readonly Utilidades _utilidades;
        public LoginController(ImportSpedContext context, Utilidades utilidades)
        {
            _context = context;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login objeto)
        {
            var UsuarioEncontrado =  _context.usuarios
                                    .Where(u =>
                                    u.nome == objeto.Usuario.ToString().ToUpper() &&
                                    u.senha == objeto.Pass
                                    ).FirstOrDefault();
            if (UsuarioEncontrado == null)
                return StatusCode(StatusCodes.Status404NotFound, new { isSucces = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSucces = true, IdUser= UsuarioEncontrado.usuario_id, token = _utilidades.GenerarJWT(UsuarioEncontrado) });
        }
        [HttpPost]
        [Route("Registrar")]
        [Authorize]
        public async Task<IActionResult> Registrar(UsuarioDTO objeto)
        {
            var modeloUsuario = new usuario
            {
                nome = objeto.nome.ToString().ToUpper(),
                senha = objeto.senha,
                email = objeto.email.ToString().ToLower(),
            };

            await _context.usuarios.AddAsync(modeloUsuario);
            await _context.SaveChangesAsync();

            if (modeloUsuario.nome == null)
                return StatusCode(StatusCodes.Status401Unauthorized, new { idSucces = false });
            else
                return StatusCode(StatusCodes.Status201Created, new { idSucces = true, IdUser = modeloUsuario.usuario_id });

        }
      
    }
}
