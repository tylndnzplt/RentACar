using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
{
    public void Configure(EntityTypeBuilder<CarModel> builder)
    {
        builder.ToTable("CarModels").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(b => b.FuelId).HasColumnName("FuelId").IsRequired();
        builder.Property(b => b.TransmissionId).HasColumnName("TransmissionId").IsRequired();
        builder.Property(b => b.DailyPrice).HasColumnName("DailyPrice").IsRequired();
        builder.Property(b => b.ImageUrl).HasColumnName("ImageUrl").IsRequired();


        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_CarModels_Name").IsUnique();//UniqueKey
        builder.HasOne(b => b.Brand);//bir modelin sadece bir markası olur
        builder.HasOne(b => b.Fuel);//bir modelin sadece bir Fueltipi olur
        builder.HasOne(b => b.Transmission);//bir modelin sadece bir Transmission tipi olur
        builder.HasMany(b => b.Cars);//bir modelin sadece bir markası olur

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);//default olarak her querye bu filtreyi uygula


    }
}
