using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Bases.Models;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("usuarios")]
    public class Usuarios : BaseModel, IUsuariosModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("nome", Order = 2, TypeName = "nvarchar")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(250)]
        public string Nome { get; set; }

        [Column("email", Order = 3, TypeName = "nvarchar")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(250)]
        public string Email { get; set; }

        [Column("senha", Order = 4, TypeName = "nvarchar")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(250)]
        public string Senha { get; set; }

        [Column("created", Order = 5, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 6, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 7, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        public override string ToString()
        {
            return Nome;
        }

        public void SetParams(string nome, string email, string senha, int status)
        {
            Nome = nome;
            Email = email;
            if (String.IsNullOrEmpty(Senha) && Senha != senha)
            {
                Senha = CryptSharp.Crypter.MD5.Crypt(senha);
            }
            else
            {
                Senha = senha;
            }
            Status = status;
        }

        public void SetParams(int id, string nome, string email, string senha, int status)
        {
            Id = id;

            SetParams(nome, email, senha, status);
        }

        public Usuarios()
        {
            UsuariosAcessos = new HashSet<UsuariosAcessos>();
        }

        public ICollection<UsuariosAcessos> UsuariosAcessos { get; set; }
    }
}