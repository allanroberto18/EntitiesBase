using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class CodigosPromocionaisService : BaseService<CodigosPromocionais>, ICodigosPromocionaisService
    {
        public override ICollection<CodigosPromocionais> Consult(string param, string field)
        {
            if (String.IsNullOrEmpty(param))
            {
                return base.Consult();
            }
            int id;
            bool teste;
            switch (field)
            {
                case "Codigo":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código especificado não é um número inteiro");
                    }
                    return List().Where(i => i.Id.Equals(id)).ToList();
                case "Promoção":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código da promoção especificado não é um número inteiro");
                    }
                    return List().Where(i => i.PromocaoId.Equals(id)).ToList();
                case "Contato":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código do Contato especificado não é um número inteiro");
                    }
                    return List().Where(i => i.ContatoId.Equals(id)).ToList();
                case "Código Promocional":
                    return List().Where(i => i.Codigo.Equals(param)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }
    }
}