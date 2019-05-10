using Roman.WebApi.Senai.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Senai.Manha.Interfaces
{
    interface IUsuarioRepositorio
    {
        List<Usuarios> Listar();
        Usuarios BuscarEmailSenha(string email, string senha);
        Usuarios BuscarUsuario(int Id);
        void Cadastrar(Usuarios usuario);
        void Alterar(Usuarios usuario);
        void Deletar(int id);
    }
}
