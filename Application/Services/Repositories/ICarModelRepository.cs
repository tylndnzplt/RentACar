using Core.Persistance.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ICarModelRepository : IAsyncRepository<CarModel, Guid>, IRepository<CarModel, Guid>
{
}
