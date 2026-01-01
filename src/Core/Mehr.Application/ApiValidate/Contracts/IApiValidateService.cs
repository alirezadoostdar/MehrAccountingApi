using Mehr.Domain.Users.Contracts.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.ApiValidate.Contracts;

public interface IApiValidateService
{
    Task<Result<bool>> IsValidate(UserLoginDto loginDto, CancellationToken cancellationToken);
}
