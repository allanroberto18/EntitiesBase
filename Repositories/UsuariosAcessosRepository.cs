using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class UsuariosAcessosRepository : BaseRepository<UsuariosAcessos>, IUsuariosAcessosRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public UsuariosAcessosRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
    }
}