using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Bases.Models;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("configuracoes")]
    public class Configuracoes : BaseModel, IConfiguracoesModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("data_inicial", Order = 2, TypeName = "datetime")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime Inicio { get; set; }

        [Column("data_final", Order = 3, TypeName = "datetime")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime Fim { get; set; }

        [Column("created", Order = 4, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 5, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 6, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        public void SetParams(DateTime inicio, DateTime fim, int status) 
        {
            Inicio = inicio;
            Fim = fim;
            Status = status;
        }

        public void SetParams(int id, DateTime inicio, DateTime fim, int status) 
        {
            Id = id;

            SetParams(inicio, fim, status);
        }

    }
}