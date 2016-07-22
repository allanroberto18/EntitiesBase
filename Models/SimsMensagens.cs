using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("sims_mensagens")]
    public class SimsMensagens
    {
        public int Id { get; set; }
        public int SimId { get; set; }
        public int Disparo { get; set; }
        public DateTime DataDisparo { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public int Status { get; set; }

        public void SetParams(int simId, int disparo, int status)
        {
            SimId = simId;
            Disparo = disparo;
            DataDisparo = DateTime.Today;
            Status = status;
        }

        public void SetParams(int id, int simId, int disparo, int status)
        {
            Id = id;

            SetParams(simId, disparo, status);
        }
    }
}