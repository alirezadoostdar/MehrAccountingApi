using Mehr.Domain.Contacts;
using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Entities.Costs;
using Mehr.Domain.Entities.Persons;
using System.Data;

namespace Mehr.Domain.Persons;

public class Person : DetailedAccount
{
    public int? FirstGroupId { get; set; }
    public PersonFirstGroup? FirstGroup { get; set; }
    public int? SecondGroupId { get; set; }
    public PersonSecondGroup? SecondGroup { get; set; }
    public float VisitorPercent { get; set; }
    public string Comment { get; set; }
    public string Introducer { get; set; }
    public long? Code { get; set; }
    public int SalePriceId { get; set; }
    public PersonSalePrice SalePrice { get; set; }
    public int? ContactInfoId { get; set; }
    public ContactInfo? ContactInfo { get; set; }
    public int? VisitorCostId { get; set; }
    public Cost? VisitorCost { get; set; }
    public decimal? VisitorBaseAmount { get; set; }
    public decimal? VisitorIncreaseAmount { get; set; }
    public float? VisitorIncresePercent { get; set; }
    public bool VisitorAutoDoc { get; set; }
    public short VisitorGoodActiveStatus { get; set; }
    public bool VisitorPercentActiveStatus { get; set; }
    public int? VisitorProductGroupId { get; set; }
    public int? KindId { get; set; }
    public PersonKind? Kind { get; set; }
    public bool? IsForeign { get; set; }
    public float? VisitorPercentChanging { get; set; }
    public string ShopName { get; set; }
    public string CardNumber { get; set; }
    public string CardId1 { get; set; }
    public string CardId2 { get; set; }
    public string BirthdayDate { get; set; }
    public string Password { get; set; }
    public decimal? Credit { get; set; }
    public int? PersonCustomerKindId { get; set; }
    public PersonCustomerKind? PersonCustomerKind { get; set; }
    public int? PersonCommercialId { get; set; }
    public PersonCommercial? PersonCommercial { get; set; }
    public string Resume { get; set; }
    public string ShippingComment { get; set; }
    public int? FirstVisitorId { get; set; }
    public int? SecondVisitorId { get; set; }
    public int? VisitorColor { get; set; }
    public bool? IsDriver { get; set; }
    public bool? IsEmployee { get; set; }
    public bool? IsDistributor { get; set; }
    public bool IsUpdate { get; set; }
    public byte? TaxKindId { get; set; }
    public PersonTaxKind? TaxKind { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public string? EshopId { get; set; }
}



public enum VisitorGoodStatus
{
    None = 0,

}