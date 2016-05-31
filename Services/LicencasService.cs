using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class LicencasService : BaseService<Licencas>, ILicencasService
    {
        public override ICollection<Licencas> Consult(string param, string field)
        {
            if (String.IsNullOrEmpty(param))
            {
                return Consult();
            }
            int id;
            switch (field)
            {
                case "Código":
                    bool teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código especificado não é um número inteiro");
                    }
                    return List().Where(i => i.Id.Equals(id)).ToList();
                case "Licença":
                    return List().Where(i => i.Licenca.Equals(param)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }

        public new ICollection<Licencas> Consult()
        {
            return this.List().OrderByDescending(i => i.Id).ToList();
        }
    }
}