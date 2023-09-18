using Core.Persistance.Repositories;
using Domain.Enums;
using System.Reflection;

namespace Domain.Entities;

public class Car : Entity<Guid>
{
    public Guid CarModelId { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate{ get; set; }
    public short MinFindexScore { get; set; } //Kredelendirme scoru (bu arabayı kiralacak kişinin minimum kredi notu)
    public CarState CarState { get; set; } //araba bakımda mı kirada mı kiralamaya uygun mu ? 

    public virtual CarModel? CarModel { get; set; }

    public Car()
    {

    }

    public Car(
        Guid id,
        Guid modelId,
        CarState carState,
        int kilometer,
        short modelYear,
        string plate,
        short minFindexScore
    )
        : this()
    {
        Id = id;
        CarModelId = modelId;
        CarState = carState;
        Kilometer = kilometer;
        ModelYear = modelYear;
        Plate = plate;
        MinFindexScore = minFindexScore;
    }
}

