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
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TemaController : ControllerBase
    {
        private ITemaRepositorio TemaRepositorio { get; set; }

        public TemaController()
        {
            TemaRepositorio = new TemaRepositorio();
        }

        [Authorize(Roles = "Administrador, Professor")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(TemaRepositorio.Listar());
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Administrador, Professor")]
        [HttpPost]
        public IActionResult Post(Tema tema)
        {
            try
            {
                TemaRepositorio.Cadastrar(tema);
                return Ok(new { mensagem = "Tema Cadastrado com Sucesso !" });

            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Administrador, Professor")]
        [HttpPut]
        public IActionResult Alterar(Tema tema)
        {
            try
            {
                TemaRepositorio.Alterar(tema);
                return Ok(TemaRepositorio.Listar());
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Administrador, Professor")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                TemaRepositorio.Deletar(id);
                return Ok(TemaRepositorio.Listar());
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Lista um único Tema especifico
        [Authorize(Roles = "Administrador, Professor")]
        [HttpGet("{Id}")]
        public IActionResult GetTema(int Id)
        {
            try
            {
                Tema temaBuscado = TemaRepositorio.BuscarTema(Id);
                if (temaBuscado == null)
                {
                    return NotFound(new { mensagem = "Tema não encontrado!" });
                }
                return Ok(temaBuscado);

            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}