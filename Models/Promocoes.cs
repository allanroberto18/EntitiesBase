using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("promocoes")]
    public class Promocoes : IPromocoes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("mensagem_id", Order = 2, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int MensagemId { get; set; }

        [Column("vencimento", Order = 3, TypeName = "datetime")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Vencimento { get; set; }

        [Column("created", Order = 4, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 5, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 6, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        [ForeignKey("MensagemId")]
        public virtual Mensagens Mensagem { get; set; }

        public ICollection<CodigosPromocionais> CodigosPromocionais { get; set; }

        public void SetParams(int mensagemId, DateTime vencimento, int status)
        {
            MensagemId = mensagemId;
            Vencimento = vencimento;
            Status = status;
        }

        public void SetParams(int id, int mensagemId, DateTime vencimento, int status)
        {
            SetParams(mensagemId, vencimento, status);
            Id = id;
        }

        public override string ToString()
        {
            return "Promoção Válida até " +  Vencimento.ToShortDateString();
        }
    }
}