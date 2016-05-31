using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface ILicencasModel : IBaseModel
    {
        void SetParams(string licenca, int status);

        void SetParams(int id, string licenca, int status);
    }
}