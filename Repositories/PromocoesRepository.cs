using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class PromocoesRepository : BaseRepository<Promocoes>, IPromocoesRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public PromocoesRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
    }
}