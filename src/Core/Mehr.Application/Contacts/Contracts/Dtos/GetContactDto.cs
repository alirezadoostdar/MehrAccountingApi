using Mehr.Domain.Contacts;
using Mehr.Domain.Zones;

namespace Mehr.Application.Contacts.Contracts.Dtos;

public class GetContactDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Comment { get; set; }
    public int CityId { get; set; }
    public string City { get; set; }

    public int StateId { get; set; }
    public int State { get; set; }

    public int ZoneId { get; set; }
    public string Zone { get; set; }

    public string ShopName { get; set; }
    public string TelegramId { get; set; }
    public string TelegramMobileNumber { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    //public ICollection<ContactNumber> Numbers { get; set; }
}
