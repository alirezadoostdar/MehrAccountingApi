namespace Mehr.Application.Contacts.Contracts.Dtos;

public class AddContactDto
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Comment { get; set; } = null!;
    public int? CityId { get; set; }
    public int? StateId { get; set; }
    public int? ZoneId { get; set; }
    public string? ShopName { get; set; }
    public string? TelegramId { get; set; }
    public string? TelegramMobileNumber { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }

    public List<AddContactNumbersDto> Numbers { get; set; } = new List<AddContactNumbersDto> { };
}

public class AddContactNumbersDto
{
    public string Number { get; set; } = null!;
    public int TypeId { get; set; }
    public string Title { get; set; } = null!;
}