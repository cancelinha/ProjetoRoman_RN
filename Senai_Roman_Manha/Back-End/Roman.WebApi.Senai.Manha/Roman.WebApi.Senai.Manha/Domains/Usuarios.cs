using System;
using System.Collections.Generic;

namespace Roman.WebApi.Senai.Manha.Domains
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdEquipe { get; set; }
        public int? IdTipoUsuario { get; set; }

        public Equipe IdEquipeNavigation { get; set; }
        public TipoUsuarios IdTipoUsuarioNavigation { get; set; }
    }
}
