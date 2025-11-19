using Mehr.SharedKernel;

namespace Mehr.Application.Docs.Contracts.Exceptions;

public static class DocErros
{
    public static Error NotFound(int id) => Error.NotFound(
    "510",
    $"The Doc with the Id = '{id}' was not found");
}
