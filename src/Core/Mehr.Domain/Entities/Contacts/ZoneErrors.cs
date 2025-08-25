using Mehr.SharedKernel;

namespace Mehr.Domain.Entities.Contacts;

public static class ZoneErrors
{
    public static Error NotFound(int id) => Error.NotFound(
    "Users.NotFound",
    $"The user with the Id = '{id}' was not found");
}
