using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Bases.Models;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("mensagens_disparos")]
    public class MensagensDisparos : BaseModel, IMensagensDisparosModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("mensagem_id", Order = 2, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int MensagemId { get; set; }

        [Column("contato_id", Order = 3, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int ContatoId { get; set; }

        [Column("tamanho", Order = 4, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Tamanho { get; set; }

        [Column("data_envio", Order = 5, TypeName = "datetime")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Envio { get; set; }

        [Column("created", Order = 6, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 7, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 8, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        [ForeignKey("MensagemId")]
        public virtual Mensagens Mensagem { get; set; }

        [ForeignKey("ContatoId")]
        public virtual Contatos Contato { get; set; }

        public void SetParams(int mensagem, int contato, int tamanho, DateTime envio, int status)
        {
            MensagemId = mensagem;
            ContatoId = contato;
            Tamanho = tamanho;
            Envio = envio;
            Status = status;
        }

        public void SetParams(int id, int mensagem, int contato, int tamanho, DateTime envio, int status)
        {
            Id = id;

            SetParams(mensagem, contato, tamanho, envio, status);
        }

        public override string ToString()
        {
            Contatos contato = Contato;

            return contato.Nome + " - " + contato.Telefone + " - " + Envio.ToShortDateString();
        }
    }
}