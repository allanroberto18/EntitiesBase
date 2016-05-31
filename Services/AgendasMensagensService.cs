using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class AgendasMensagensService : BaseService<AgendasMensagens>, IAgendasMensagensService
    {
        public override ICollection<AgendasMensagens> Consult(string param, string field)
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
                case "Mensagem":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código da mensagem especificado não é um número inteiro");
                    }
                    return List().Where(i => i.MensagemId.Equals(id)).ToList();
                case "DataEnvio":
                    DateTime dataEnvio;
                    teste = DateTime.TryParse(param, out dataEnvio);
                    if (!teste)
                    {
                        throw new Exception("A data de envio especificada não é uma data válida");
                    }
                    return List().Where(i => i.Envio.Equals(dataEnvio) && i.Status.Equals(1)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }

        public ICollection<AgendasMensagens> ConsultByMensagemByEnvio(int mensagem, DateTime envio)
        {
            return List().Where(i => i.MensagemId.Equals(mensagem) && i.Envio.Equals(envio)).ToList();
        }

        public bool ValidarNovo(int id, DateTime dataAtual)
        {
            bool value = false;

            ICollection<AgendasMensagens> amList =
                List().Where(i => i.MensagemId.Equals(id) && i.Envio.Equals(dataAtual)).ToList();
            int count = amList.Count;
            if (count == 0)
            {
                value = true;
            }

            return value;
        }

        public new void Add(AgendasMensagens item)
        {
            bool check = ValidarNovo(item.MensagemId, item.Envio);
            if (check)
            {
                base.Add(item);
            }
        }
    }
}