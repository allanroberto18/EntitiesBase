using System.Collections.Generic;
using Entities.Bases.Services;
using Entities.Models;

namespace Entities.Interfaces.Services
{
    public interface IContatosMensagensService : IBaseService<ContatosMensagens>
    {
        void CheckUpdate(int contatoId, int mensagemId, int status);
        void ProcessarExclusaoContatosByMensagemByGrupo(int mensagem, ICollection<GruposContatos> gruposContatos);
        void RemoverMensagemContatoByMensagemByContato(int mensagem, int contato);
    }
}