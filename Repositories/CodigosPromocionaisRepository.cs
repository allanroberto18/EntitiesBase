using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class CodigosPromocionaisRepository : BaseRepository<CodigosPromocionais>, ICodigosPromocionaisRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public CodigosPromocionaisRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
    }
}
