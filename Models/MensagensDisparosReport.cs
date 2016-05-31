using System;

namespace Entities.Models
{
    public class MensagensDisparosReport
    {
        public int Id { get; set; }
        public string Contato { get; set; }
        public string Mensagem { get; set; }
        public DateTime Envio { get; set; }
    }
}