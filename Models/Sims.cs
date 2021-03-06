﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Bases.Models;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("sims")]
    public class Sims : BaseModel, ISimsModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("sim", Order=2, TypeName = "nvarchar")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public String Sim { get; set; }


        [Column("data_atual", Order = 3, TypeName = "date")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DataAtual { get; set; }

        [Column("quantidade", Order = 4, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Quantidade { get; set; }

        [Column("created", Order = 5, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 6, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 7, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        public void SetParams(string sim, int status)
        {
            Sim = sim;
            Quantidade = 0;
            DataAtual = DateTime.Today;
            Status = status;
        }

        public void SetParams(int id, string sim, int quantidade, int status)
        {
            Id = id;
            Quantidade = quantidade;
            SetParams(sim, status);
        }
    }
}