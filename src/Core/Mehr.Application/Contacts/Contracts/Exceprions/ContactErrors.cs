using Mehr.SharedKernel;

namespace Mehr.Application.Contacts.Contracts.Exceprions;

public static class ContactErrors 
{
    public static Error NotFound(int id) => Error.NotFound(
    "510",
    $"The Contact with the Id = '{id}' was not found");
}
