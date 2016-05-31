using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class ConfiguracoesRepository : BaseRepository<Configuracoes>, IConfiguracoesRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public ConfiguracoesRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
    }
}
