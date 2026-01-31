using IMS.Core.Exceptions;

namespace IMS.UseCases.Exceptions;

public class InventoryNotFoundException(Guid id) : NotFoundException("Inventory", id) { }
