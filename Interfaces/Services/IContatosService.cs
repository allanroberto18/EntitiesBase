using System.Collections.Generic;
using Entities.Bases.Services;
using Entities.Models;

namespace Entities.Interfaces.Services
{
    public interface IContatosService : IBaseService<Contatos>
    {
        ICollection<Contatos> Consult(string param, string field, int sexo);
    }
}