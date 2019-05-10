using System;
using System.Collections.Generic;

namespace Roman.WebApi.Senai.Manha.Domains
{
    public partial class Estado
    {
        public Estado()
        {
            Projetos = new HashSet<Projetos>();
        }

        public int Id { get; set; }
        public string Estado1 { get; set; }

        public ICollection<Projetos> Projetos { get; set; }
    }
}
