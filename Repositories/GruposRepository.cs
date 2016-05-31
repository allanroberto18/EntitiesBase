using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class GruposRepository : BaseRepository<Grupos>, IGruposRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public GruposRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
    }
}
