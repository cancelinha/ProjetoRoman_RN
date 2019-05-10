using Microsoft.EntityFrameworkCore;
using Roman.WebApi.Senai.Manha.Domains;
using Roman.WebApi.Senai.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Senai.Manha.Repositorios
{
    public class TemaRepositorio : ITemaRepositorio
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog= SENAI_DESAFIO_ROMAN; user id = sa; pwd = 132";

        public List<Tema> Listar()
        {
            using (RomanContext ctx = new RomanContext())
            {
                //.Include(C => C.Usuarios).
                return ctx.Tema.Include(C => C.Projetos).ToList();
            }
        }

        public void Cadastrar(Tema tema)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Tema.Add(tema);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Tema.Remove(ctx.Tema.Find(id));
                ctx.SaveChanges();
            }
        }

        public void Alterar(Tema tema)
        {
            using (RomanContext ctx = new RomanContext())
            {
                Tema temaExiste = ctx.Tema.Find(tema.Id);

                if
                (temaExiste.Id == tema.Id)
                {
                    temaExiste.Tema1 = tema.Tema1;
                                

                    ctx.Tema.Update(temaExiste);
                    ctx.SaveChanges();
                }

            }
        }

        public Tema BuscarTema(int Id)
        {
            Tema temaBuscado = new Tema();

            using (RomanContext ctx = new RomanContext())
            {
                temaBuscado = ctx.Tema.Find(Id);
            }
            return temaBuscado;
        }


    }
}
