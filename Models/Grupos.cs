using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Bases.Models;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("grupos")]
    public class Grupos : BaseModel, IGruposModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("nome", Order = 2, TypeName = "nvarchar")]
        [StringLength(250)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Column("created", Order = 3, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 4, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 5, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        public void SetParams(string nome, int status)
        {
            Nome = nome.ToUpper();
            Status = status;
        }

        public void SetParams(int id, string nome, int status)
        {
            Id = id;

            SetParams(nome, status);
        }

        public override string ToString()
        {
            return Nome;
        }

        public Grupos()
        {
            GruposContatos = new HashSet<GruposContatos>();

            GruposMensagens = new HashSet<GruposMensagens>();
        }

        public ICollection<GruposContatos> GruposContatos { get; set; }

        public ICollection<GruposMensagens> GruposMensagens { get; set; }
    }
}