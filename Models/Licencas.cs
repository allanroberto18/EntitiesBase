using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Bases.Models;
using Entities.Interfaces.Models;

namespace Entities.Models
{
    [Table("licencas")]
    public class Licencas : BaseModel, ILicencasModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Column("licenca", Order = 2, TypeName = "nvarchar")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(250)]
        public string Licenca { get; set; }

        [Column("created", Order = 3, TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column("updated", Order = 4, TypeName = "datetime")]
        public DateTime? Updated { get; set; }

        [Column("status", Order = 5, TypeName = "int")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Status { get; set; }

        public override string ToString()
        {
            return Licenca == null ? "Sistema Liberado" : "Licença: " + Licenca;
        }

        public void SetParams(string licenca, int status)
        {
            Licenca = licenca;
            Status = status;
        }

        public void SetParams(int id, string licenca, int status)
        {
            Id = id;

            SetParams(licenca, status);
        }
    }
}