using System;

namespace Entities.Models
{
    public class GruposContatosReport
    {
        public int Id { get; set; } 

        public string Contato { get; set; }

        public string Sexo { get; set; }

        public string Telefone { get; set; }

        public string Grupo { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}