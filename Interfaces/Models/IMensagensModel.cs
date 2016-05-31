using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface IMensagensModel : IBaseModel
    {
        void SetParams(int tipo, string mensagem, int sexo, int status);
        void SetParams(int id, int tipo, string mensagem, int sexo, int status);
        string ReturnTipo();
    }
}