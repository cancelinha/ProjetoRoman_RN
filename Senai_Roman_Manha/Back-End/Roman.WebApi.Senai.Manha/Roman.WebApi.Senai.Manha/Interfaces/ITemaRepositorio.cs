using Roman.WebApi.Senai.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Senai.Manha.Interfaces
{
    interface ITemaRepositorio
    {
        List<Tema> Listar();
        Tema BuscarTema(int Id);
        void Cadastrar(Tema tema);
        void Alterar(Tema tema);
        void Deletar(int id);
    }
}
