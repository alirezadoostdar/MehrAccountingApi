namespace Mehr.Domain.Contacts;

public class ContactNumber
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Title { get; set; }

    public int ContactTypeId { get; set; }
    public ContactType ContactType { get; set; }

    public int ContactInfoId { get; set; }
    public ContactInfo ContactInfo { get; set; }
}