using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Bases.Models;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("contatos_mensagens")]
    public class ContatosMensagens : BaseModel, IContatosMensagensModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("contato_id", Order = 2, TypeName = "int")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int ContatoId { get; set; }

        [Column("mensagem_id", Order = 3, TypeName = "int")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int MensagemId { get; set; }

        [Column("created", Order = 4, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 5, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 6, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        [ForeignKey("ContatoId")]
        public virtual Contatos Contato { get; set; }

        [ForeignKey("MensagemId")]
        public Mensagens Mensagem { get; set; }
        
        public void SetParams(int mensagem, int contato, int status)
        {
            MensagemId = mensagem;
            ContatoId = contato;
            Status = status;
        }

        public void SetParams(int id, int mensagem, int contato, int status)
        {
            Id = id;

            SetParams(mensagem, contato, status);
        }
    }
}