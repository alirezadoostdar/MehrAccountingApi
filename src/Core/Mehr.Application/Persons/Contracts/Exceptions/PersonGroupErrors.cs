using Mehr.SharedKernel;

namespace Mehr.Application.Persons.Contracts.Exceptions;

public static class PersonGroupErrors
{
    public static Error NotFound(int id) => Error.NotFound(
    "510",
    $"The Person Group with the Id = '{id}' was not found");

    public static Error IsDuplicate(string title) => Error.Conflict(
    "510",
    $"The Person Group with the Title = '{title}' is duplicate");

    public static Error IsUsed(int id) => Error.Conflict(
    "510",
     $"The Person Group with the id = '{id}' is used");
}
