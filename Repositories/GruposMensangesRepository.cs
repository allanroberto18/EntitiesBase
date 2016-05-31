using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class GruposMensangesRepository : BaseRepository<GruposMensagens>, IGruposMensagensRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public GruposMensangesRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
    }
}
