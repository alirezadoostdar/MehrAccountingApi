namespace Mehr.Domain.Contacts;

public class ContactImage
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] Image { get; set; }
    public int ContactInfoId { get; set; }
}
