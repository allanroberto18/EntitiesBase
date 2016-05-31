using Entities.Bases.Context;
using Entities.Bases.Repositories;
using Entities.Interfaces.Repositories;
using Entities.Models;

namespace Entities.Repositories
{
    public class LicencasRepository : BaseRepository<Licencas>, ILicencasRepository
    {
        IUnitOfWork unitOfWork = new EntityContext();

        public LicencasRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
    }
}