using Mehr.Domain.Users.Contracts.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.ApiValidate.Contracts;

public interface IApiValidateService
{
    Task<Result<DateTime>> IsValidate(UserLoginDto loginDto, CancellationToken cancellationToken);
}
