using System;
using System.Collections.Generic;

namespace Roman.WebApi.Senai.Manha.Domains
{
    public partial class Equipe
    {
        public Equipe()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
