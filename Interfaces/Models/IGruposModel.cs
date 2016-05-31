using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface IGruposModel : IBaseModel
    {
        void SetParams(string nome, int status);
        void SetParams(int id, string nome, int status);
    }
}