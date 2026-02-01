using IMS.Core.Enums;
using IMS.Core.ValueObjects;

namespace IMS.Infrastructure.Data.Extensions;

public static class InitialData
{
    public static IEnumerable<Inventory> Inventories =>
        new List<Inventory>
        {
            Inventory.Add(
                InventoryId.Of(new Guid("6a7f4f72-cd00-4676-a99a-f718ad40937f")),
                InventoryName.Of("Bicycle Pedals"),
                50,
                QuantityType.Count,
                5.50m
            ),
            Inventory.Add(
                InventoryId.Of(new Guid("b36d926f-1b1d-46ef-bf3e-ac4e60c70ba6")),
                InventoryName.Of("Bicycle Seat"),
                20,
                QuantityType.Count,
                20m
            ),
            Inventory.Add(
                InventoryId.Of(new Guid("eabf36ff-97fe-496d-bb77-8be07b773f54")),
                InventoryName.Of("Bicycle Wheel"),
                40,
                QuantityType.Count,
                30m
            ),
        };
}
