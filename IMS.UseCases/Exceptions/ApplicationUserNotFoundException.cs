using IMS.Core.Exceptions;

namespace IMS.UseCases.Exceptions;

public class ApplicationUserNotFoundException(Guid id)
    : NotFoundException("ApplicationUser", id) { }
