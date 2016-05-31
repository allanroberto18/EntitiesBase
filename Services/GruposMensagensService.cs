using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class GruposMensagensService : BaseService<GruposMensagens>, IGruposMensagensService
    {
        public override ICollection<GruposMensagens> Consult(string param, string field)
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
                        throw new Exception("O código informado deve ser um número inteiro");
                    }
                    return List().Where(i => i.Id.Equals(id)).ToList();
                case "Grupo":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código do grupo que foi informado deve ser um número inteiro");
                    }
                    return List().Where(i => i.GrupoId.Equals(id)).ToList();
                case "Mensagem":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código da mensagem que foi informado deve ser um número inteiro");
                    }
                    return List().Where(i => i.MensagemId.Equals(id)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }

        public void FindRemoveByMensagemAndGrupo(int mensagem, int grupo)
        {
            ICollection<GruposMensagens> list = List().Where(i => i.MensagemId.Equals(mensagem) && i.GrupoId.Equals(grupo)).ToList();
            int count = list.Count;
            if (count == 0)
            {
                return;
            }
            foreach (GruposMensagens item in list)
            {
                Remove(item);
            }

            GruposContatosService service = new GruposContatosService();
            service.FindContatosByGrupo(grupo, mensagem);
        }

        public new void Add(GruposMensagens entity)
        {
            int mensagem = entity.MensagemId;
            int grupo = entity.GrupoId;

            ICollection<GruposMensagens> list =
                List().Where(i => i.MensagemId.Equals(mensagem) && i.GrupoId.Equals(grupo)).ToList();
            int count = list.Count;

            if (count == 0)
            {
                base.Add(entity);

                ContatosMensagensService msgService = new ContatosMensagensService();
                msgService.AdicionarContatosMensagem(grupo, mensagem);
            }
        }

        public int ReturnCountGrupos(int mensagem)
        {
            return List().Count(i => i.MensagemId.Equals(mensagem));
        }
    }
}