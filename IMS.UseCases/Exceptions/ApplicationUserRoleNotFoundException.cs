using IMS.Core.Exceptions;

namespace IMS.UseCases.Exceptions;

public class ApplicationUserRoleNotFoundException(Guid id)
    : NotFoundException("ApplicationUserRole", id) { }
