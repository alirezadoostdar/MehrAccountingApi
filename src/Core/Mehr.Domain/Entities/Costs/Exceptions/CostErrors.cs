using Mehr.SharedKernel;

namespace Mehr.Domain.Entities.Costs.Exceptions;

public static class CostErrors
{
    public static Error NotFound(int id) => Error.NotFound(
        "Users.NotFound",
        $"The user with the Id = '{id}' was not found");


    public static Error FirstGroupNotFound(int id) => Error.NotFound(
    "CostFirstGroup.NotFound",
    $"The cost first group with the Id = '{id}' was not found");

    public static Error FirstGroupIsUsed(int id) => Error.Conflict(
    "CostFirstGroup.IsUsed",
    $"The cost first group with the Id = '{id}' is used");



    public static Error SecondGroupNotFound(int id) => Error.NotFound(
        "CostSecondGroup.NotFound",
        $"The cost second group with the Id = '{id}' was not found");
    public static Error SecondGroupIsUsed(int id) => Error.Conflict(
        "CostSecondGroup.IsUsed",
        $"The cost second group with the Id = '{id}' is used");


}
