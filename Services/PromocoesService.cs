using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class PromocoesService : BaseService<Promocoes>, IPromocoesService
    {
        public override ICollection<Promocoes> Consult(string param, string field)
        {
            if (String.IsNullOrEmpty(param))
            {
                return base.Consult(param, field);
            }
            int id;
            bool teste;
            DateTime vencimento;
            switch (field)
            {
                case "Código":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código especificado não é um número inteiro");
                    }
                    return List().Where(i => i.Id.Equals(id)).ToList();
                case "Mensagem":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código da mensagem especificado não é um número inteiro");
                    }
                    return List().Where(i => i.MensagemId.Equals(id)).ToList();
                case "Vencimento":
                    teste = DateTime.TryParse(param, out vencimento);
                    if (!teste)
                    {
                        throw new Exception("A data de vencimento especificada não é uma data válida");
                    }
                    return List().Where(i => i.Vencimento.Equals(vencimento) && i.Status.Equals(1)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }
    }
}