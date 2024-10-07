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
    [AllowAnonymous]
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
        public async Task<IActionResult> Login(Login objeto)
        {
            var UsuarioEncontrado = await _context.usuarios
                                    .Where(u =>
                                    u.nome == objeto.Usuario.ToString().ToUpper() &&
                                    u.senha == objeto.Pass
                                    //_utilidades.EncriptarSHA256(objeto.Password)
                                    ).FirstOrDefaultAsync();
            if (UsuarioEncontrado == null)
                return StatusCode(StatusCodes.Status200OK, new { isSucces = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSucces = true, token = _utilidades.GenerarJWT(UsuarioEncontrado) });
        }
        //[HttpPost]
        //[Route("Registrar")]
        //public async Task<IActionResult> Registrar(UsuarioDTO objeto)
        //{
        //    var modeloUsuario = new Usuario
        //    {
        //        Nombre = objeto.Nombre,
        //        Clave = _utilidades.EncriptarSHA256(objeto.Clave),
        //        Correo = objeto.Correo,
        //    };

        //    await _context.Usuarios.AddAsync(modeloUsuario);
        //    await _context.SaveChangesAsync();

        //    if (modeloUsuario.Clave == null)
        //        return StatusCode(StatusCodes.Status401Unauthorized, new { idSucces = false });
        //    else
        //        return StatusCode(StatusCodes.Status201Created, new { idSucces = true });

        //}
        //private readonly IServicioUsuario _servicioUsuario;
        //private readonly IConfiguration _configuration;
        //public LoginController(IServicioUsuario servicioUsuario, IConfiguration configuration)
        //{
        //    this._servicioUsuario = servicioUsuario;
        //    this._configuration = configuration;
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<ActionResult<UsuarioDTO>> Login(Login login)
        //{
        //    UsuarioAPI usuario = null;

        //    usuario = await AutenticarUsuario(login);
        //    if (usuario is null)
        //    {
        //        throw new Exception("Credenciales no validas.");
        //    }
        //    else
        //    {
        //        usuario = GenerarTokenJWT(usuario);
        //    }


        //    return usuario.ToDTO();
        //}

        //private async Task<UsuarioAPI> AutenticarUsuario(Login login)
        //{
        //    UsuarioAPI usuarioAPI = await _servicioUsuario.GetUsuario(login);
        //    return usuarioAPI;
        //}

        //private UsuarioAPI GenerarTokenJWT(UsuarioAPI usuarioInfo)
        //{
        //    var _symmetricSecurityKey = new SymmetricSecurityKey(
        //        Encoding.UTF8.GetBytes(_configuration["JWT:ClaveSecreta"])
        //    );

        //    var _signingCredentials = new SigningCredentials(
        //        _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
        //    );

        //    var _Header = new JwtHeader(_signingCredentials);

        //    var _Claims = new[] {
        //        new Claim("usuario", usuarioInfo.usuario),
        //        new Claim("email", usuarioInfo.email),
        //        new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.email)
        //    };

        //    var _Payload = new JwtPayload(
        //        issuer: _configuration["JWT:issuer"],
        //        audience: _configuration["JWT:Audience"],
        //        claims: _Claims,
        //        notBefore: DateTime.UtcNow,
        //        expires: DateTime.UtcNow.AddMinutes(30)
        //    );

        //    var _Token = new JwtSecurityToken(
        //        _Header,
        //        _Payload
        //    );

        //    usuarioInfo.token = new JwtSecurityTokenHandler().WriteToken(_Token);

        //    return usuarioInfo;
        //}
    }
}
