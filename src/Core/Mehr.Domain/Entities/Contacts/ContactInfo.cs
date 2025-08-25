namespace Mehr.Domain.Entities.Contacts;

public class ContactInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Comment { get; set; }
    public ContactSecurityType SecurityType { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }

    public int StateId { get; set; }
    public int State { get; set; }

    public int ZoneId { get; set; }
    public Zone Zone { get; set; }

    public string ShopName { get; set; }
    public string TelegramId { get; set; }
    public string TelegramMobileNumber { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string Location { get; set; }

    public ICollection<ContactNumber> Numbers { get; set; }
}


public enum ContactSecurityType
{
    Public = 1,
    Private = 2
}
