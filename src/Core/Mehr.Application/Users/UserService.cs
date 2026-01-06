using Mehr.Application.Users.Contracts;
using Mehr.Application.Users.Contracts.Exceptions;
using Mehr.Domain.Users;
using Mehr.Domain.Users.Contracts;
using Mehr.Domain.Users.Contracts.Dtos;
using Mehr.SharedKernel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Mehr.Application.ApiValidate.Contracts;
using Mehr.Application.ApiValidate.Contracts.Exceptions;

namespace Mehr.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApiValidateService _apiValidateService;

    public UserService(IUserRepository repository, IUnitOfWork unitOfWork, IApiValidateService apiValidateService)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _apiValidateService = apiValidateService;
    }

    public async Task<Result<GetUserDto>> GetUserById(int id, CancellationToken cancellation)
    {
        var user = await _repository.GetUserByIdAsync(id, cancellation);

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

    public async Task<Result<string>> UserLoginAsync(UserLoginDto dto, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUserByUsernameAsync(dto.Username, cancellationToken);

        if (user is null)
            return Result.Failure<string>(UserErrors.NotValid());

        if (user.IsDisable)
            return Result.Failure<string>(UserErrors.IsSuspend(dto.Username));

        if (!CheckPassword(dto.Password, user.Password))
            return Result.Failure<string>(UserErrors.NotValid());

        var resValidateService = await _apiValidateService.IsValidate(dto, cancellationToken);

        if (!resValidateService.IsSuccess)
            return Result.Failure<string>(resValidateService.Error);

        var token = CreateToken(user, (DateTime)resValidateService.Value);
        return token;
    }

    private bool CheckPassword(string password, string hashPassword)
    {

        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        var NewPassWordHash = md5.ComputeHash(Encoding.ASCII.GetBytes($"ab32asd{password}a876qefg"));
        string paswwordH = Encoding.ASCII.GetString(NewPassWordHash);
        if (paswwordH != hashPassword)
        {
            return false;
        }
        return true;

    }
    private string CreateToken(User user, DateTime validDate)
    {

        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("c0d0cd85-f64e-4fcd-8625-c8c37c5bdd85"));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("userId", user.Id.ToString()));
        claimsForToken.Add(new Claim("UserName", user.UserName.ToString()));
        claimsForToken.Add(new Claim("GroupId", user.RoleId.ToString()));
        claimsForToken.Add(new Claim("SecureLevel", user.SecureLevel.ToString()));
        var jwtSecurityToke = new JwtSecurityToken(
            "Jwt:Issuer",
            "Jwt:Audience",
            claimsForToken,
            DateTime.Now,
            validDate,
            signingCredentials
            );

        var tokenToReturn = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToke);
        return tokenToReturn;
    }
}

