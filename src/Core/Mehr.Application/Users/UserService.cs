using Mehr.Application.Users.Contracts;
using Mehr.Domain.Users.Contracts.Dtos;

namespace Mehr.Application.Users;

internal class UserService : IUserService
{
    public Task<GetUserDto> GetUserById(int id, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}
}
