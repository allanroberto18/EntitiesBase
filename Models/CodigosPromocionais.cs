using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Bases.Models;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("codigos_promocionais")]
    public class CodigosPromocionais : BaseModel, ICodigosPromocionaisModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("promocao_id", Order = 2, TypeName = "int")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int PromocaoId { get; set; }

        [Column("contato_id", Order = 3, TypeName = "int")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int ContatoId { get; set; }

        [Column("codigo", Order = 4, TypeName = "nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Codigo { get; set; }

        [Column("created", Order = 5, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 6, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 7, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        [ForeignKey("promocaoId")]
        public virtual Promocoes Promocao { get; set; }

        [ForeignKey("ContatoId")]
        public virtual Contatos Contato { get; set; }

        public override string ToString()
        {
            return Codigo;
        }

        public void SetParams(int promocao, int contatos, string codigo, int status) 
        {
            PromocaoId = promocao;
            ContatoId = contatos;
            Codigo = codigo;
            Status = status;
        }

        public void SetParams(int id, int promocao, int contato, string codigo, int status)
        {
            Id = id;

            SetParams(promocao, contato, codigo, status);
        }
    }
}