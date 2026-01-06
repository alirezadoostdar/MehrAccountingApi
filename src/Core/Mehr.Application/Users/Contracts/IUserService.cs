
using Mehr.Domain.Users.Contracts.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.Users.Contracts;

public interface IUserService
{
    Task<Result<GetUserDto>> GetUserById(int id, CancellationToken cancellation);
    Task<Result<string>> UserLoginAsync(UserLoginDto dto, CancellationToken cancellationToken);
}
