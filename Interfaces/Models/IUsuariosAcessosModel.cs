using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface IUsuariosAcessosModel : IBaseModel
    {
        void SetParams(int usuario, int status);
        void SetParams(int id, int usuario, int status);
    }
}