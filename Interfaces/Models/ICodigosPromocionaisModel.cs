using Entities.Bases.Models;

namespace Entities.Interfaces.Models
{
    public interface ICodigosPromocionaisModel : IBaseModel
    {
        void SetParams(int promocao, int contatos, string codigo, int status);

        void SetParams(int id, int promocao, int contato, string codigo, int status);
    }
}