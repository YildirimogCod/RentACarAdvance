using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CarRepository:EfRepositoryBase<Car,Guid,BaseDbContext>
    {
        public CarRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
