using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CarModelId).HasColumnName("CarModelId").IsRequired();
        builder.Property(b => b.Kilometer).HasColumnName("Kilometer").IsRequired();
        builder.Property(b => b.CarState).HasColumnName("State").IsRequired();
        builder.Property(b => b.ModelYear).HasColumnName("ModelYear").IsRequired();


        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.CarModel);


        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);//default olarak her querye bu filtreyi uygula//softdeleate yapısıyla çalışıyoruz



    }
}