using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class TransmissionRepository: EfRepositoryBase<Transmission, Guid, BaseDbContext>
    {
        public TransmissionRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
