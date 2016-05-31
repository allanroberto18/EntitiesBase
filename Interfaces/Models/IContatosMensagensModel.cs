using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface IContatosMensagensModel : IBaseModel
    {
        void SetParams(int mensagem, int contato, int status);
        void SetParams(int id, int mensagem, int contato, int status);
    }
}