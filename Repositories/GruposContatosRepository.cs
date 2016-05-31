using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class GruposContatosRepository : BaseRepository<GruposContatos>, IGruposContatosRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public GruposContatosRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
    }
}
