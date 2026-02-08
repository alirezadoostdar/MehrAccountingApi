using Mehr.SharedKernel;

namespace Mehr.Application.Persons.Contracts.Exceptions;

public static class PersonErros
{
    public static Error NotFound(int id) => Error.NotFound(
    "510",
    $"The Person with the Id = '{id}' was not found");
}
