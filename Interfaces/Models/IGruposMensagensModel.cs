using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface IGruposMensagensModel : IBaseModel
    {
        void SetParams(int grupo, int mensagem, int status);

        void SetParams(int id, int grupo, int mensagem, int status);
    }
}