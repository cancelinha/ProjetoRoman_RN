using Microsoft.EntityFrameworkCore;
using Roman.WebApi.Senai.Manha.Domains;
using Roman.WebApi.Senai.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Senai.Manha.Repositorios
{
    public class EquipeRepositorio : IEquipeRepositorio
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog= SENAI_DESAFIO_ROMAN; user id = sa; pwd = 132";

        public List<Equipe> Listar()
        {
            using (RomanContext ctx = new RomanContext())
            {
                return ctx.Equipe.Include(C => C.Usuarios).ToList();
            }
        }

        public void Cadastrar(Equipe equipe)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Equipe.Add(equipe);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Equipe.Remove(ctx.Equipe.Find(id));
                ctx.SaveChanges();
            }
        }

        public void Alterar(Equipe equipe)
        {
            using (RomanContext ctx = new RomanContext())
            {
                Equipe equipeExiste = ctx.Equipe.Find(equipe.Id);

                if
                (equipeExiste.Id == equipe.Id)
                {
                    equipeExiste.Nome = equipe.Nome;
                    //equipeExiste.Usuarios = equipe.Usuarios;                   
                    ctx.Equipe.Update(equipeExiste);
                    ctx.SaveChanges();
                }

            }
        }

        public Equipe BuscarEquipe(int Id)
        {
            Equipe equipeBuscada = new Equipe();

            using (RomanContext ctx = new RomanContext())
            {
                equipeBuscada = ctx.Equipe.Find(Id);
            }
            return equipeBuscada;
        }
    }
}
