﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Bases.Models;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("grupos_contatos")]
    public class GruposContatos : BaseModel, IGruposContatosModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("grupo_id", Order = 2, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int GrupoId { get; set; }

        [Column("contato_id", Order = 3, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int ContatoId { get; set; }

        [Column("created", Order = 4, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 5, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 6, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        [ForeignKey("GrupoId")]
        public virtual Grupos Grupo { get; set; }

        [ForeignKey("ContatoId")]
        public virtual Contatos Contato { get; set; }

        public void SetParams(int grupo, int contato, int status)
        {
            GrupoId = grupo;
            ContatoId = contato;
            Status = status;
        }

        public void SetParams(int id, int grupo, int contato, int status)
        {
            Id = id;

            SetParams(grupo, contato, status);
        }
    }
}