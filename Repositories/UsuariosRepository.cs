using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class UsuariosRepository : BaseRepository<Usuarios>, IUsuariosRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public UsuariosRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
    }
}