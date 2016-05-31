using Entities.Bases.Services;
using Entities.Models;

namespace Entities.Interfaces.Services
{
    public interface IUsuariosAcessosService : IBaseService<UsuariosAcessos>
    {
        void LiberarPrimeiroAcesso();
    }
}