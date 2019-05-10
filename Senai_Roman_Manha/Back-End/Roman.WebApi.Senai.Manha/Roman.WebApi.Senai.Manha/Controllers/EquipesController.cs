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
    [Produces("application/json")]
    [ApiController]
    public class EquipesController : ControllerBase
    {
        private IEquipeRepositorio EquipeRepositorio { get; set; }

        public EquipesController()
        {
            EquipeRepositorio = new EquipeRepositorio();
        }

        [Authorize(Roles = "Administrador, Professor")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(EquipeRepositorio.Listar());
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Administrador, Professor")]
        [HttpPost]
        public IActionResult Post(Equipe equipe)
        {
            try
            {
                EquipeRepositorio.Cadastrar(equipe);
                return Ok(new { mensagem = "Equipe Cadastrada com Sucesso !" });

            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Administrador, Professor")]
        [HttpPut]
        public IActionResult Alterar(Equipe equipe)
        {
            try
            {
                EquipeRepositorio.Alterar(equipe);
                return Ok(EquipeRepositorio.Listar());
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
                EquipeRepositorio.Deletar(id);
                return Ok(EquipeRepositorio.Listar());
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Lista uma única Equipe especifica
        [Authorize(Roles = "Administrador, Professor")]
        [HttpGet("{Id}")]
        public IActionResult GetEquipe(int Id)
        {
            try
            {
                Equipe equipeBuscada = EquipeRepositorio.BuscarEquipe(Id);
                if (equipeBuscada == null)
                {
                    return NotFound(new { mensagem = "Equipe não encontrada!" });
                }
                return Ok(equipeBuscada);

            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}