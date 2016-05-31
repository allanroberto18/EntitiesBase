using System.Collections.Generic;
using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class SimsRepository : BaseRepository<Sims>, ISimsRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public SimsRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
            
        }
    }
}
