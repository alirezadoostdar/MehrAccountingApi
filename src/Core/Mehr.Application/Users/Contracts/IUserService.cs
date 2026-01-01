
using Mehr.Domain.Users.Contracts.Dtos;

namespace Mehr.Application.Users.Contracts;

public interface IUserService
{
    Task<GetUserDto> GetUserById(int id, CancellationToken cancellation);

}
