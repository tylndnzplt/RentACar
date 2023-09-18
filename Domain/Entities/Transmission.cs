using Core.Persistance.Repositories;
using System.Reflection;

namespace Domain.Entities;

public class Transmission : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<CarModel> CarModels { get; set; }

    public Transmission()
    {
        CarModels = new HashSet<CarModel>();
    }

    public Transmission(Guid id, string name)
        : this()
    {
        Id = id;
        Name = name;
    }
}

