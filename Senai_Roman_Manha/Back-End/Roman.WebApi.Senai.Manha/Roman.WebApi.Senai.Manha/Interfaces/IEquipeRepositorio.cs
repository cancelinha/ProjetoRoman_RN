using Roman.WebApi.Senai.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Senai.Manha.Interfaces
{
    interface IEquipeRepositorio
    {
        List<Equipe> Listar();
        Equipe BuscarEquipe(int Id);
        void Cadastrar(Equipe equipe);
        void Alterar(Equipe equipe);
        void Deletar(int id);
    }
}
