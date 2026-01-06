using Mehr.SharedKernel;

namespace Mehr.Application.Users.Contracts.Exceptions;

public class UserErrors
{
    public static Error NotFound(int id) => Error.NotFound(
"510",
$"The user with the Id = '{id}' was not found");

    public static Error NotValid() => Error.Failure(
"510",
$"The username or password is not valid");

    public static Error IsSuspend(string userName) => Error.Failure(
"510",
$"This account({userName}) is suspended");
}
