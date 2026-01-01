using Mehr.Application.Users.Contracts;
using Mehr.Application.Users.Contracts.Exceptions;
using Mehr.Domain.Users.Contracts;
using Mehr.Domain.Users.Contracts.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetUserDto>> GetUserById(int id, CancellationToken cancellation)
    {
        var user = await _repository.GetUserById(id, cancellation);
        if (user is null)
            return Result.Failure<GetUserDto>(UserErrors.NotFound(id));
        return new GetUserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            IsDisable = user.IsDisable,
            RoleId = user.RoleId,
            SecureLevel = user.SecureLevel
        };
    }
}

