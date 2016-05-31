using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface IGruposContatosModel : IBaseModel
    {
        void SetParams(int grupo, int contato, int status);

        void SetParams(int id, int grupo, int contato, int status);
    }
}