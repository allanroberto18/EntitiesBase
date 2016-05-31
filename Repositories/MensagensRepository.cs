using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class MensagensRepository : BaseRepository<Mensagens>, IMensagensRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public MensagensRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
    }
}