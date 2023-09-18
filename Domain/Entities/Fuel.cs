using Core.Persistance.Repositories;
using System.Reflection;

namespace Domain.Entities;

public class Fuel : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<CarModel> CarModels { get; set; }

    public Fuel()
    {
        CarModels = new HashSet<CarModel>();
    }

    public Fuel(Guid id, string name)
        : this()
    {
        Id = id;
        Name = name;
    }
}

