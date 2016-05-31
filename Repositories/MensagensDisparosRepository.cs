using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class MensagensDisparosRepository :  BaseRepository<MensagensDisparos>, IMensagensDisparosRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public MensagensDisparosRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
    }
}