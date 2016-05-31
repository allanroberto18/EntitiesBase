using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class MensagensService : BaseService<Mensagens>, IMensagensService
    {
        public override ICollection<Mensagens> Consult(string param, string field)
        {
            if (String.IsNullOrEmpty(param))
            {
                return base.Consult();
            }
            int id;
            switch (field)
            {
                case "Codigo":
                    bool teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código especificado não é um número inteiro");
                    }
                    return List().Where(i => i.Id.Equals(id)).ToList();
                case "Mensagem":
                    return List().Where(i => i.Mensagem.Equals(param)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }

        public new ICollection<Mensagens> Consult()
        {
            return List().Where(i => i.Status < 9).OrderByDescending(i => i.Id).ToList();
        }
    }
}