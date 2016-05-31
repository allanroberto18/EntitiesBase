using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class GruposService : BaseService<Grupos>, IGruposService
    {
        public override ICollection<Grupos> Consult(string param, string field)
        {
            if (String.IsNullOrEmpty(param))
            {
                return base.Consult();
            }
            int id;
            switch (field)
            {
                case "Código":
                    bool teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código informado deve ser um número inteiro");
                    }
                    return List().Where(i => i.Id.Equals(id)).ToList();
                case "Nome":
                    return List().Where(i => i.Nome.Contains(param)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }

        public new ICollection<Grupos> Consult()
        {
            return List().Where(i => i.Status.Equals(1)).OrderByDescending(i => i.Id).ToList();
        } 
    }
}