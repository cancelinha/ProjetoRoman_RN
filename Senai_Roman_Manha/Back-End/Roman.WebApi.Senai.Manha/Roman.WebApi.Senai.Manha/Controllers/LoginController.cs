using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Roman.WebApi.Senai.Manha.Domains;
using Roman.WebApi.Senai.Manha.Interfaces;
using Roman.WebApi.Senai.Manha.Repositorios;
using Roman.WebApi.Senai.Manha.ViewModel;

namespace Roman.WebApi.Senai.Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepositorio UsuarioRepositorio { get; set; }

        public LoginController()
        {
            UsuarioRepositorio = new UsuarioRepositorio();
        }
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {

                Usuarios usuarioBuscado = UsuarioRepositorio.BuscarEmailSenha(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Email ou senha inválido"
                    });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation.Nome.ToString()),
                    new Claim("TipoUsuarios", usuarioBuscado.IdTipoUsuarioNavigation.Nome.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("roman-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Roman.WebApi",
                    audience: "Roman.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}