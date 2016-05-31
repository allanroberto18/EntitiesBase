using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class MensagensDisparosService : BaseService<MensagensDisparos>, IMensagensDisparosService
    {
        public override ICollection<MensagensDisparos> Consult(string param, string field)
        {
            if (String.IsNullOrEmpty(param))
            {
                return Consult();
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
                case "Contato":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código do contato especificado não é um número inteiro");
                    }
                    return List().Where(i => i.ContatoId.Equals(id)).ToList();
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

        public int ReturnCountDisparos()
        {
            ICollection<MensagensDisparos> list = Consult();
            int countList = list.Count;
            if (countList == 0)
            {
                return countList;
            }
            int count = 0;
            foreach (MensagensDisparos item in list)
            {
                count += ProcessarTamanhoSMS(item.Tamanho);
            }
            return count;
        }

        public int ProcessarTamanhoSMS(int tamanho)
        {
            if (tamanho <= 160)
                return 1;
            if (tamanho <= 320)
                return 2;
            if (tamanho <= 480)
                return 3;
            return 4;
        }
    }
}