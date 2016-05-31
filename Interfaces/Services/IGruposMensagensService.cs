using Entities.Bases.Services;
using Entities.Models;

namespace Entities.Interfaces.Services
{
    public interface IGruposMensagensService : IBaseService<GruposMensagens>
    {
        void FindRemoveByMensagemAndGrupo(int mensagem, int grupo);
    }
}