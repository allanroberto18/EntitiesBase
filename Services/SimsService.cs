using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class SimsService : BaseService<Sims>, ISimsService
    {
        public override ICollection<Sims> Consult(string param, string field)
        {
            if (String.IsNullOrEmpty(param))
            {
                return base.Consult();
            }
            int id;
            bool teste;
            switch (field)
            {
                case "Código":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código especificado não é um número inteiro");
                    }
                    return List().Where(i => i.Id.Equals(id)).ToList();
                case "Sim":
                    return List().Where(i => i.Sim.Equals(param)).ToList();
                case "Data de Criação":
                    DateTime dataCriacao;
                    teste = DateTime.TryParse(param, out dataCriacao);
                    if (!teste)
                    {
                        throw new Exception("A data de criação especificada não é uma data válida");
                    }
                    return List().Where(i => i.Created.Equals(dataCriacao)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }
    }
}