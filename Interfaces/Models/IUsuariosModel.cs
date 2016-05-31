using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface IUsuariosModel : IBaseModel
    {
        void SetParams(string nome, string email, string senha, int status);

        void SetParams(int id, string nome, string email, string senha, int status);
    }
}