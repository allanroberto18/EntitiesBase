using System.Collections.Generic;
using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class AgendasMensagensRepository : BaseRepository<AgendasMensagens>, IAgendasMensagensRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public AgendasMensagensRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
            
        }
    }
}
