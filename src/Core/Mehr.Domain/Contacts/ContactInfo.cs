using Mehr.Domain.Zones;
using NetTopologySuite.Geometries;

namespace Mehr.Domain.Contacts;

public class ContactInfo
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Comment { get; set; } = null!;
    public ContactSecurityType SecurityType { get; set; }
    public int? CityId { get; set; }
    public City? City { get; set; }

    public int? StateId { get; set; }
    public State? State { get; set; }

    public int? ZoneId { get; set; }
    public Zone? Zone { get; set; }

    public string? ShopName { get; set; }
    public string? TelegramId { get; set; }
    public string? TelegramMobileNumber { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public Geometry? Location { get; set; }

    public ContactImage? Image { get; set; }

    public ICollection<ContactNumber> Numbers { get; set; } = new List<ContactNumber>();
}


public enum ContactSecurityType
{
    Public = 0,
    Private = 1
}
