using Entities.Bases.Services;
using Entities.Models;

namespace Entities.Interfaces.Services
{
    public interface IGruposContatosService : IBaseService<GruposContatos>
    {
        void FindContatosByGrupo(int id, int mensagem);

        void Remove(int grupo, int contato);
    }
}