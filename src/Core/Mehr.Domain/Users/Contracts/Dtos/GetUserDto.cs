namespace Mehr.Domain.Users.Contracts.Dtos;

public class GetUserDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public int SecureLevel { get; set; }
    public bool IsDisable { get; set; }
}
