using Microsoft.Identity.Client;

namespace Mehr.Domain.Entities.Docs;

public class Doc
{
    public int Id { get; set; }
    public string ShamsiDate { get; set; }
    public DateTime CreateAt { get; set; }
    public int UserId { get; set; }
    public UserAssertion MyProperty { get; set; }
}
