using IMS.Core.ValueObjects;
using IMS.UseCases.Data;
using IMS.UseCases.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IMS.UseCases.Inventory.Queries.GetInventoryDetails;

public class GetInventoryDetailsQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetInventoryDetailsQuery, GetInventoryDetailsResult>
{
    public async Task<GetInventoryDetailsResult> Handle(
        GetInventoryDetailsQuery query,
        CancellationToken cancellationToken
    )
    {
        var inventory = await dbContext
            .Inventories.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == InventoryId.Of(query.InventoryId), cancellationToken);

        if (inventory is null)
        {
            throw new InventoryNotFoundException(query.InventoryId);
        }

        var mappedInventoryDto = inventory.Adapt<InventoryDto>();

        return new GetInventoryDetailsResult(mappedInventoryDto);
    }
}
