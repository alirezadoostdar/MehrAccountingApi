using Mehr.SharedKernel;

namespace Mehr.Domain.Entities.Costs.Exceptions;

public static class CostErrors
{
    public static Error NotFound(int id) => Error.NotFound(
        "Users.NotFound",
        $"The user with the Id = '{id}' was not found");


    public static Error FirsGroupNotFound(int id) => Error.NotFound(
    "CostFirstGroup.NotFound",
    $"The cost first group with the Id = '{id}' was not found");
}
