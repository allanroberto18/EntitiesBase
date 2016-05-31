using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Bases.Models;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("mensagens")]
    public class Mensagens : BaseModel, IMensagensModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("tipo", Order = 2, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Tipo { get; set; }
        
        [Column("mensagem", Order = 3, TypeName = "text")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Mensagem { get; set; }
        
        [Column("sexo", Order = 4, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Sexo { get; set; }

        [Column("created", Order = 5, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 6, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 7, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        public Mensagens()
        {
            AgendasMensagens = new HashSet<AgendasMensagens>();
            Promocoes = new HashSet<Promocoes>();
            ContatosMensagens = new List<ContatosMensagens>();
            GruposMensagens = new List<GruposMensagens>();
            MensagensDisparos = new List<MensagensDisparos>();
        }

        public void SetParams(int tipo, string mensagem, int sexo, int status)
        {
            Tipo = tipo;
            Mensagem = mensagem;
            Sexo = sexo;
            Status = status;
        }

        public void SetParams(int id, int tipo, string mensagem, int sexo, int status)
        {
            Id = id;

            SetParams(tipo, mensagem, sexo, status);
        }

        public override string ToString()
        {
            return Mensagem;
        }

        public ICollection<AgendasMensagens> AgendasMensagens { get; set; }

        public ICollection<Promocoes> Promocoes { get; set; }

        public ICollection<ContatosMensagens> ContatosMensagens { get; set; }

        public ICollection<GruposMensagens> GruposMensagens { get; set; }

        public ICollection<MensagensDisparos> MensagensDisparos { get; set; }

        public string ReturnTipo()
        {
            string value = "";
            switch (Tipo)
            {
                case 1:
                    value = "Com Nome";
                    break;
                case 2:
                    value = "Sem Nome";
                    break;
            }
            return value;
        }
    }
}