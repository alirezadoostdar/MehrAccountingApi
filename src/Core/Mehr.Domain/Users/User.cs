using Mehr.Domain.Entities.Accounts;

namespace Mehr.Domain.Users;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public int SecureLevelId { get; set; }
    public string Password { get; set; }
    public bool IsDisable { get; set; }
    public DateTime ModifiedAt { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }
}
