using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roman.WebApi.Senai.Manha.Domains;
using Roman.WebApi.Senai.Manha.Interfaces;
using Roman.WebApi.Senai.Manha.Repositorios;

namespace Roman.WebApi.Senai.Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepositorio UsuarioRepositorio { get; set; }

        public UsuariosController()
        {
            UsuarioRepositorio = new UsuarioRepositorio();
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {       
                return Ok(UsuarioRepositorio.Listar());
            }
            catch(SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Usuarios usuario)
        {
            try
            {
                UsuarioRepositorio.Cadastrar(usuario);
                return Ok(new { mensagem = "Usuário Cadastrado com Sucesso !" });

            } catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            } 

        }
        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult Alterar(Usuarios usuario)
        {
            try
            {
                //Usuarios usuarioExiste = new Usuarios();
                UsuarioRepositorio.Alterar(usuario);
                return Ok(UsuarioRepositorio.Listar());
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                UsuarioRepositorio.Deletar(id);
                return Ok(UsuarioRepositorio.Listar());
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Lista um único Usuario especifico
        [Authorize(Roles = "Administrador")]
        [HttpGet("{Id}")]
        public IActionResult GetUsuario(int Id)
        {
            try
            {
               Usuarios usuarioBuscado =  UsuarioRepositorio.BuscarUsuario(Id);
                if(usuarioBuscado == null)
                {
                    return NotFound(new { mensagem = "Usuário não encontrado!" });
                }
                return Ok(usuarioBuscado);

            }catch(SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}