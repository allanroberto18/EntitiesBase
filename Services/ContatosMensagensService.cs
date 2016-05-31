using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Services;
using Entities.Interfaces.Services;
using Entities.Models;

namespace Entities.Services
{
    public class ContatosMensagensService : BaseService<ContatosMensagens>, IContatosMensagensService
    {
        public override ICollection<ContatosMensagens> Consult(string param, string field)
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
                case "Mensagem":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código da mensagem especificado não é um número inteiro");
                    }
                    return List().Where(i => i.MensagemId.Equals(id)).ToList();
                case "Pendentes":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código da mensagem especificado não é um número inteiro");
                    }
                    return List().Where(i => i.MensagemId.Equals(id) && i.Status.Equals(1)).ToList();
                case "Processados":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código da mensagem especificado não é um número inteiro");
                    }
                    return List().Where(i => i.MensagemId.Equals(id) && i.Status.Equals(2)).ToList();
                case "Contato":
                    teste = int.TryParse(param, out id);
                    if (!teste)
                    {
                        throw new Exception("O código do Contato especificado não é um número inteiro");
                    }
                    return List().Where(i => i.ContatoId.Equals(id)).ToList();

                default:
                    return List().Where(i => i.Status.Equals(1)).ToList();
            }
        }

        public void CheckUpdate(int contatoId, int mensagemId, int status=2)
        {
            ContatosMensagens cm =
                List().First(i => i.ContatoId.Equals(contatoId) && i.MensagemId.Equals(mensagemId));

            cm.Status = status;

            Edit(cm);
        }

        public void ProcessarExclusaoContatosByMensagemByGrupo(int mensagem, ICollection<GruposContatos> gruposContatos)
        {
            int count = gruposContatos.Count;
            if (count == 0)
            {
                return;
            }

            foreach (GruposContatos item in gruposContatos)
            {
                RemoverMensagemContatoByMensagemByContato(mensagem, item.ContatoId);
            }
        }

        public void AdicionarContatosMensagem(int grupo, int mensagem)
        {
            GruposContatosService gcService = new GruposContatosService();
            ICollection<GruposContatos> list = gcService.Consult(grupo.ToString(), "Grupo");

            int count = list.Count;
            if (count == 0)
                return;

            foreach (GruposContatos item in list)
            {
                ContatosMensagens entity = new ContatosMensagens();
                entity.SetParams(mensagem, item.ContatoId, 1);
                entity.Created = DateTime.Now;

                Add(entity);
            }
        }

        public void RemoverMensagemContatoByMensagemByContato(int mensagem, int contato)
        {
            ICollection<ContatosMensagens> listLigacao =
                List().Where(i => i.MensagemId.Equals(mensagem) && i.ContatoId.Equals(contato)).ToList();
            int count = listLigacao.Count;

            if (count == 0)
            {
                return;
            }

            foreach (ContatosMensagens item in listLigacao)
            {
                Remove(item);
            }
        }

        public int ReturnCountContatos(int mensagem)
        {
            return List().Count(i => i.MensagemId.Equals(mensagem));
        }

        public new void Add(ContatosMensagens entity)
        {
            int mensagem = entity.MensagemId;
            int contato = entity.ContatoId;

            ICollection<ContatosMensagens> list =
                List().Where(i => i.MensagemId.Equals(mensagem) && i.ContatoId.Equals(contato)).ToList();
            int count = list.Count;

            if (count == 0)
            {
                base.Add(entity);
            }
        }

        public void ReorganizarContatosMensagens(int mensagem)
        {
            ICollection<ContatosMensagens> processados = Consult(mensagem.ToString(), "Processados");
            ICollection<ContatosMensagens> pendentes = Consult(mensagem.ToString(), "Pendentes");
            int countProcessados = processados.Count;
            int countPendentes = pendentes.Count;

            if (countPendentes > 0 || countProcessados == 0)
            {
                return;
            }

            foreach (ContatosMensagens item in processados)
            {
                item.Status = 1;
                Edit(item);
            }
        }
    }
}