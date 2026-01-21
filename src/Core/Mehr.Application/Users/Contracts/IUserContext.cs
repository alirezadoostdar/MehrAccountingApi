namespace Mehr.Application.Users.Contracts;

public interface IUserContext
{
    int UserId { get; }
    int GroupId { get; }
    string UserName { get; }
    int SecureLevel { get; }
}
