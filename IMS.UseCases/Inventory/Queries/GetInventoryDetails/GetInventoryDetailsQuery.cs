namespace IMS.UseCases.Inventory.Queries.GetInventoryDetails;

public record GetInventoryDetailsQuery(Guid InventoryId) : IQuery<GetInventoryDetailsResult>;

public record GetInventoryDetailsResult(InventoryDto Inventory);
