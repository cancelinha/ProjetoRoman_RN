using Roman.WebApi.Senai.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Senai.Manha.Interfaces
{
    interface IProjetoRepositorio
    {
        List<Projetos> Listar();
        Projetos BuscarProjeto(int Id);
        void Cadastrar(Projetos projetos);
        void Alterar(Projetos projetos);
        void Deletar(int id);
    }
}
