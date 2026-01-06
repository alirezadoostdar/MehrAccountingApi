using Mehr.SharedKernel;

namespace Mehr.Application.ApiValidate.Contracts.Exceptions;

public static class ApiValidateErrors
{
    public static Error NoFeature() => Error.Failure(
        "101",
        "User doe not has api feature");

    public static Error NotFound() => Error.NotFound(
        "102",
        "User not found");

    public static Error NoValidDate() => Error.Failure(
        "104",
        "Not has valid date or api key not correct");

    public static Error Unexpected() => Error.Failure(
        "500",
        "Unexpected error");
}
