using Mehr.SharedKernel;

namespace Mehr.Domain.Zones;

public static class ZoneErrors
{
    public static Error NotFound(int id) => Error.NotFound(
    "Zones.NotFound",
    $"The zone with the Id = '{id}' was not found");

    public static Error DuplicateTitle(string title) => Error.Failure(
           "Zones.DuplicateTitle",
           $"The title of zone ({title}) is duplicate");
}
