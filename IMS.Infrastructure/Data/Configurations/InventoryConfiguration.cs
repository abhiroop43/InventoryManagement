using IMS.Core.Enums;
using IMS.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMS.Infrastructure.Data.Configurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(inv => inv.Value, val => InventoryId.Of(val));

        builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Quantity).HasColumnType("decimal(18,2)");

        builder.ComplexProperty(
            x => x.ItemName,
            nameBuilder =>
            {
                nameBuilder
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Inventory.ItemName))
                    .HasMaxLength(100)
                    .IsRequired();
            }
        );

        builder
            .Property(x => x.QuantityType)
            .HasDefaultValue(QuantityType.Count)
            .HasConversion(
                qType => qType.ToString(),
                dbQType => (QuantityType)Enum.Parse(typeof(QuantityType), dbQType)
            );
    }
}
