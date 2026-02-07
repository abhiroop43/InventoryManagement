namespace IMS.UseCases.Inventory.Queries.GetInventoryDetails;

public class GetInventoryDetailsQueryHandler
    : IQueryHandler<GetInventoryDetailsQuery, GetInventoryDetailsResult>
{
    public async Task<GetInventoryDetailsResult> Handle(
        GetInventoryDetailsQuery request,
        CancellationToken cancellationToken
    )
    {
        return new GetInventoryDetailsResult(null!);
    }
}
