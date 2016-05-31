using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class ContatosRepository : BaseRepository<Contatos>, IContatosRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public ContatosRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
    }
}
