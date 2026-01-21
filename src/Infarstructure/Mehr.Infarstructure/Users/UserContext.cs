using Mehr.Application.Users.Contracts;
using Microsoft.AspNetCore.Http;

namespace Mehr.Infarstructure.Users;

public class UserContext : IUserContext
{
    public int UserId { get; }

    public int GroupId { get; }

    public string UserName { get; }

    public int SecureLevel { get; }
    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User;

        if (user is not null)
        {
            UserId = Convert.ToInt32(user?.FindFirst("UserId")?.Value!);
            GroupId = Convert.ToInt32(user?.FindFirst("GroupId")?.Value!);
            SecureLevel = Convert.ToInt32(user?.FindFirst("SecureLevel")?.Value!);
            UserName = user?.FindFirst("UserName")?.Value!;
        }
    }
}
