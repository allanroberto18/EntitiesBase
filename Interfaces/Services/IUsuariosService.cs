using Entities.Bases.Services;
using Entities.Models;

namespace Entities.Interfaces.Services
{
    public interface IUsuariosService : IBaseService<Usuarios>
    {
        Usuarios GetRegisterByEmail(string email);
        bool TestUsuariosByEmail(string email);
        Usuarios GetLogin(string email, string senha);
    }
}