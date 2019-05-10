using Roman.WebApi.Senai.Manha.Domains;
using Roman.WebApi.Senai.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Senai.Manha.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog= SENAI_DESAFIO_ROMAN; user id = sa; pwd = 132";

        public List<Usuarios> Listar()
        {
            using (RomanContext ctx = new RomanContext())
            {
                return ctx.Usuarios.Where(x=>x.IdTipoUsuario == 2).ToList();
            }
        }
        
        public void Cadastrar(Usuarios usuario)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public Usuarios BuscarEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = @"select u.id, u.email, u.senha, u.id_tipo_usuario, tu.nome as nometipousuario 
                        from usuarios u inner join TIPO_USUARIOS tu on tu.ID = u.ID_TIPO_USUARIO
                        where email = @email and senha = @senha";

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        Usuarios usuario = new Usuarios();

                        while (sdr.Read())
                        {
                            usuario.Id = Convert.ToInt32(sdr["id"]);
                            usuario.Email = sdr["email"].ToString();
                            usuario.IdTipoUsuarioNavigation = new TipoUsuarios();
                            usuario.IdTipoUsuarioNavigation.Nome = sdr["nometipousuario"].ToString();
                        }
                        return usuario;
                    }
                }
                return null;
            }
        }
        public void Deletar(int id)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Usuarios.Remove(ctx.Usuarios.Find(id));
                ctx.SaveChanges();
            }
        }

        public void Alterar (Usuarios usuario)
        {
            using (RomanContext ctx = new RomanContext())
            {
                Usuarios usuarioExiste = ctx.Usuarios.Find(usuario.Id);

                if
                (usuarioExiste.Id == usuario.Id)
                {
                    usuarioExiste.IdEquipe = usuario.IdEquipe;
                    usuarioExiste.IdEquipeNavigation = usuario.IdEquipeNavigation;
                    usuarioExiste.Email = usuarioExiste.Email;
                    usuarioExiste.IdTipoUsuario = usuario.IdTipoUsuario;
                    usuarioExiste.IdTipoUsuarioNavigation = usuario.IdTipoUsuarioNavigation;
                    usuarioExiste.Nome = usuario.Nome;
                    usuarioExiste.Senha = usuario.Senha;
                    ctx.Usuarios.Update(usuarioExiste);
                    ctx.SaveChanges();
                }

            }
        }
       


        public Usuarios BuscarUsuario(int Id)
        {
            Usuarios usuarioBuscado = new Usuarios();

            using (RomanContext ctx = new RomanContext())
            {
                usuarioBuscado = ctx.Usuarios.Find(Id);
            }
            return usuarioBuscado;
        }
    }
}


