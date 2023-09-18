using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories;

public class CarModelRepository : EfRepositoryBase<CarModel, Guid, BaseDbContext>, ICarModelRepository
{
    public CarModelRepository(BaseDbContext context) : base(context)
    {
    }
}
