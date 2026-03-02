using Mehr.Domain.Contacts;

namespace Mehr.Application.Contacts.Contracts.Dtos;

public class GetContactNumberDto
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Title { get; set; }

    public byte ContactTypeId { get; set; }
    public string ContactType { get; set; }

}
