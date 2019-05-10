using System;
using System.Collections.Generic;

namespace Roman.WebApi.Senai.Manha.Domains
{
    public partial class Projetos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? IdTema { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string Descricao { get; set; }
        public int? IdEstado { get; set; }

        public Estado IdEstadoNavigation { get; set; }
        public Tema IdTemaNavigation { get; set; }
    }
}
