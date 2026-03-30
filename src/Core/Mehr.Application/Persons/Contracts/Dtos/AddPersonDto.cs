using Mehr.Application.Contacts.Contracts.Dtos;
using Mehr.Domain.Contacts;
using Mehr.Domain.Entities.Costs;
using Mehr.Domain.Entities.Persons;
using Mehr.Domain.Persons;

namespace Mehr.Application.Persons.Contracts.Dtos;

public class AddPersonDto
{
    public string Title { get; set; }
    public int? FirstGroupId { get; set; }
    public int? SecondGroupId { get; set; }
    public string Comment { get; set; }
    public string Introducer { get; set; }
    public long Code { get; set; }
    public int SalePriceId { get; set; }
    public AddContactDto? ContactInfo { get; set; }
    public string ShopName { get; set; }
    public PersonCustomerKind? PersonCustomerKind { get; set; }

}
