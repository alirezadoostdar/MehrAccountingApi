

using Mehr.SharedKernel;

namespace Mehr.Application.DetailedAccounts.Contracts.Exceptions;

public static class DetailedAccountError
{
    public static Error NotFound(int id) => Error.NotFound(
        "DetaileAccount.NotFound",
        $"The detaileAccount with the Id = '{id}' was not found");
}
