using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Bases.Models;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("agendas_mensagens")]
    public class AgendasMensagens : BaseModel, IAgendasMensagensModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("mensagem_id", Order=2, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int MensagemId { get; set; }

        [Column("data_envio", Order=3, TypeName = "datetime")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Envio { get; set; }

        [Column("created", Order = 4, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 5, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 6, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        [ForeignKey("MensagemId")]
        public virtual Mensagens Mensagem { get; set; }

        public void SetParams(int mensagem, DateTime envio, int status)
        {
            MensagemId = mensagem;
            Envio = envio;
            Status = status;
        }

        public void SetParams(int id, int mensagem, DateTime envio, int status)
        {
            Id = id;

            SetParams(mensagem, envio, status);
        }
    }
}