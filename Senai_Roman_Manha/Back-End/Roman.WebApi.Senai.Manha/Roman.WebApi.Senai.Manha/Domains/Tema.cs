using System;
using System.Collections.Generic;

namespace Roman.WebApi.Senai.Manha.Domains
{
    public partial class Tema
    {
        public Tema()
        {
            Projetos = new HashSet<Projetos>();
        }

        public int Id { get; set; }
        public string Tema1 { get; set; }

        public ICollection<Projetos> Projetos { get; set; }
    }
}
