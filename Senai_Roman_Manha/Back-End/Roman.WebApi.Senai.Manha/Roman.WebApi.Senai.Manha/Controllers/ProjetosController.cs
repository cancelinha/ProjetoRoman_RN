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
    public class ProjetosController : ControllerBase
    {
        private IProjetoRepositorio ProjetoRepositorio { get; set; }

        public ProjetosController()
        {
            ProjetoRepositorio = new ProjetoRepositorio();
        }

        [Authorize(Roles = "Administrador, Professor")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(ProjetoRepositorio.Listar());
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Administrador, Professor")]
        [HttpPost]
        public IActionResult Post(Projetos projeto)
        {
            try
            {
                ProjetoRepositorio.Cadastrar(projeto);
                return Ok(new { mensagem = "Projeto Cadastrado com Sucesso !" });

            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Administrador, Professor")]
        [HttpPut]
        public IActionResult Alterar(Projetos projeto)
        {
            try
            {
                ProjetoRepositorio.Alterar(projeto);
                return Ok(ProjetoRepositorio.Listar());
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
                ProjetoRepositorio.Deletar(id);
                return Ok(ProjetoRepositorio.Listar());
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Lista um único Projeto especifico
        [Authorize(Roles = "Administrador, Professor")]
        [HttpGet("{Id}")]
        public IActionResult GetProjeto(int Id)
        {
            try
            {
                Projetos projetoBuscado = ProjetoRepositorio.BuscarProjeto(Id);
                if (projetoBuscado == null)
                {
                    return NotFound(new { mensagem = "Projeto não encontrado!" });
                }
                return Ok(projetoBuscado);

            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}