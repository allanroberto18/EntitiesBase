using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class GruposContatosService : BaseService<GruposContatos>, IGruposContatosService
    {
        public override ICollection<GruposContatos> Consult(string param, string field)
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
                case "Contato":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código do contato que foi informado deve ser um número inteiro");
                    }
                    return List().Where(i => i.ContatoId.Equals(id)).ToList();
                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }

        public void FindContatosByGrupo(int id, int mensagem)
        {
            ICollection<GruposContatos> list = Consult(id.ToString(), "Grupo");
            int count = list.Count;
            if (count == 0)
            {
                return;
            }

            ContatosMensagensService service = new ContatosMensagensService();
            service.ProcessarExclusaoContatosByMensagemByGrupo(mensagem, list);
        }

        public void Remove(int grupo, int contato)
        {
            ICollection<GruposContatos> list =
                List().Where(i => i.GrupoId.Equals(grupo) && i.ContatoId.Equals(contato)).ToList();
            int count = list.Count;
            if (count == 0)
            {
                return;
            }

            foreach (GruposContatos item in list)
            {
                base.Remove(item);
            }
        }

        public new void Add(GruposContatos entity)
        {
            int grupo = entity.GrupoId;
            int contato = entity.ContatoId;

            ICollection<GruposContatos> list =
                List().Where(i => i.GrupoId.Equals(grupo) && i.ContatoId.Equals(contato)).ToList();

            int count = list.Count;
            if (count > 0)
            {
                return;
            }
            base.Add(entity);
        }
    }
}