using Roman.WebApi.Senai.Manha.Domains;
using Roman.WebApi.Senai.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Senai.Manha.Repositorios
{
    public class ProjetoRepositorio : IProjetoRepositorio
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog= SENAI_DESAFIO_ROMAN; user id = sa; pwd = 132";

        public List<Projetos> Listar()
        {
            using (RomanContext ctx = new RomanContext())
            {
                //.Include(C => C.Usuarios).
                return ctx.Projetos.ToList();
            }
        }

        public void Cadastrar(Projetos projeto)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Projetos.Add(projeto);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Projetos.Remove(ctx.Projetos.Find(id));
                ctx.SaveChanges();
            }
        }

        public void Alterar(Projetos projeto)
        {
            using (RomanContext ctx = new RomanContext())
            {
                Projetos projetoExiste = ctx.Projetos.Find(projeto.Id);

                if
                (projetoExiste.Id == projeto.Id)
                {
                    projetoExiste.Nome = projeto.Nome;
                    projetoExiste.Descricao = projeto.Descricao;
                    projetoExiste.DataCriacao = projeto.DataCriacao;
                    projetoExiste.IdEstado = projeto.IdEstado;
                    projetoExiste.IdEstadoNavigation = projeto.IdEstadoNavigation;
                    projetoExiste.IdTema = projeto.IdTema;
                    projetoExiste.IdTemaNavigation = projeto.IdTemaNavigation;
                    
                    ctx.Projetos.Update(projetoExiste);
                    ctx.SaveChanges();
                }

            }
        }

        public Projetos BuscarProjeto(int Id)
        {
            Projetos projetoBuscado = new Projetos();

            using (RomanContext ctx = new RomanContext())
            {
                projetoBuscado = ctx.Projetos.Find(Id);
            }
            return projetoBuscado;
        }
    }
}
