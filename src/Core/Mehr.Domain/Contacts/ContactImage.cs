namespace Mehr.Domain.Contacts;

public class ContactImage
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public byte[] Image { get; set; } = null!;
    public int ContactInfoId { get; set; }
    public ContactInfo ContactInfo { get; set; } = null!;
}
