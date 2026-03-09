namespace Mehr.Domain.Contacts;

public class ContactNumber
{
    public int Id { get; set; }
    public string Number { get; set; } = null!;
    public string Title { get; set; } = null!;

    public int ContactTypeId { get; set; }
    public ContactType ContactType { get; set; } = null!;

    public int ContactInfoId { get; set; }
    public ContactInfo ContactInfo { get; set; } = null!;
}