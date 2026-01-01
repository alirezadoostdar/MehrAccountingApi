using Mehr.SharedKernel;

namespace Mehr.Application.Users.Contracts.Exceptions;

public class UserErrors
{
    public static Error NotFound(int id) => Error.NotFound(
"510",
$"The user with the Id = '{id}' was not found");
}
