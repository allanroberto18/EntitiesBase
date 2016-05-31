using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Bases.Models;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("usuarios_acessos")]
    public class UsuariosAcessos : BaseModel, IUsuariosAcessosModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("usuario_id", Order = 2, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int UsuarioId { get; set; }

        [Column("created", Order = 3, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 4, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 5, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuario { get; set; }

        public void SetParams(int usuario, int status)
        {
            UsuarioId = usuario;

            Status = status;
        }

        public void SetParams(int id, int usuario, int status)
        {
            Id = id;

            SetParams(usuario, status);
        }
    }
}