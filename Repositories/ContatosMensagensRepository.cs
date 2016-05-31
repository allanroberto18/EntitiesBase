using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class ContatosMensagensRepository : BaseRepository<ContatosMensagens>, IContatosMensagensRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public ContatosMensagensRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
    }
}
