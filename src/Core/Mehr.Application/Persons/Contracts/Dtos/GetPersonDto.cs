namespace Mehr.Application.Persons.Contracts.Dtos;

public class GetPersonDto
{
    public string Title { get; set; }
    public decimal CreditLimit { get; set; }
    public int? FirstGroupId { get; set; }
    public int? SecondGroupId { get; set; }
    public string Comment { get; set; }
    public string Introducer { get; set; }
    public long? Code { get; set; }
    public int SalePriceId { get; set; }
    public int? ContactInfoId { get; set; }
    public int VisitorCostId { get; set; }
    public decimal VisitorBaseAmount { get; set; }
    public decimal VisitorIncreaseAmount { get; set; }
    public float VisitorIncresePercent { get; set; }
    public bool VisitorAutoDoc { get; set; }
    public short VisitorGoodActiveStatus { get; set; }
    public bool VisitorPercentActiveStatus { get; set; }
    public int VisitorProductGroupId { get; set; }
    public int? KindId { get; set; }
    public bool IsForeign { get; set; }
    public int VisitorPercentChanging { get; set; }
    public string ShopName { get; set; }
    public string CardNumber { get; set; }
    public string CardId1 { get; set; }
    public string CardId2 { get; set; }
    public string BirthdayDate { get; set; }
    public string Password { get; set; }
    public decimal Credit { get; set; }
    public int? PersonCustomerKindId { get; set; }
    public int? PersonCommercialId { get; set; }
    public string Resume { get; set; }
    public string ShippingComment { get; set; }
    public int? FirstVisitorId { get; set; }
    public int? SecondVisitorId { get; set; }
    public int? VisitorColor { get; set; }
    public bool IsDriver { get; set; }
    public bool IsEmployee { get; set; }
    public bool IsDistributor { get; set; }
    public bool IsUpdate { get; set; }
    public byte? TaxKindId { get; set; }
}