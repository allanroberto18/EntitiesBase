using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Bases.Models;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("contatos")]
    public class Contatos : BaseModel, IContatosModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("nome", Order = 2, TypeName = "nvarchar")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(250)]
        public string Nome { get; set; }

        [Column("sexo", Order = 3, TypeName = "int")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Sexo { get; set; }

        [Column("telefone", Order = 4, TypeName = "nvarchar")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(15)]
        public string Telefone { get; set; }

        [Column("data_nascimento", Order = 5, TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        [Column("created", Order = 6, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 7, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 8, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        public override string ToString()
        {
            return Nome;
        }

        public void SetParams(string nome, int sexo, string telefone, int status) 
        {
            Nome = nome;
            Sexo = sexo;
            Telefone = telefone;
            Status = status;
        }

        public void SetParams(string nome, int sexo, string telefone, DateTime dataNascimento, int status)
        {
            DataNascimento = dataNascimento;

            SetParams(nome, sexo, telefone, status);
        }

        public void SetParams(int id, string nome, int sexo, string telefone, int status)
        {
            Id = id;

            SetParams(nome, sexo, telefone, status);
        }

        public void SetParams(int id, string nome, int sexo, string telefone, DateTime dataNascimento, int status)
        {
            DataNascimento = dataNascimento;

            SetParams(id, nome, sexo, telefone, status);
        }

        public Contatos() 
        {
            CodigosPromocionais = new HashSet<CodigosPromocionais>();
            ContatosMensagens = new HashSet<ContatosMensagens>();
            GruposContatos = new HashSet<GruposContatos>();
            MensagensDisparos = new HashSet<MensagensDisparos>();
        }

        public ICollection<CodigosPromocionais> CodigosPromocionais { get; set; }

        public ICollection<ContatosMensagens> ContatosMensagens { get; set; }

        public ICollection<GruposContatos> GruposContatos { get; set; }

        public ICollection<MensagensDisparos> MensagensDisparos { get; set; }
    }
}