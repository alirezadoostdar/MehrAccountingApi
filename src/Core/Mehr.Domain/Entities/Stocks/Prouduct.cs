namespace Mehr.Domain.Entities.Stocks;

public class Prouduct
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Code { get; set; }
    public string Barcode { get; set; }
    public ProductType Type { get; set; }
    public string FirstUnit { get; set; }
    public string SecondUnit { get; set; }
    public double UnitRate { get; set; }
    public float OrderPoint { get; set; }
    public decimal SalePrice1 { get; set; }
    public decimal SalePrice2 { get; set; }
    public decimal SalePrice3 { get; set; }
    public decimal SalePrice4 { get; set; }
    public decimal SalePrice5 { get; set; }
    public double VisitorPercent { get; set; }
    public string Comment { get; set; }
    public double DiscountPercent { get; set; }
    public decimal UserPrice { get; set; }

    public int ProductGroup1Id { get; set; }
    public ProductGroup1 ProductGroup1 { get; set; }

    public int ProductGroup2Id { get; set; }
    public ProductGroup2 productGroup2 { get; set; }

    public bool HasSerial { get; set; }
    public float Weight { get; set; }
    public string Term { get; set; }
    public double Tax1 { get; set; }
    public double Tax2 { get; set; }
    public bool HasDateExpire { get; set; }
    public bool DateExpireAlarm { get; set; }
    public string TechnicalDescription { get; set; }
    public double MaximumQuantity { get; set; }
    public bool RightToLeft { get; set; } = true;
    public bool UnderSalePrice { get; set; } = false;
    public bool IsCardDiscount { get; set; }
    public bool NotReturn { get; set; }
    public string Field1 { get; set; }
    public string Field2 { get; set; }
    public string Field3 { get; set; }
    public bool HasPromotion { get; set; }
    public decimal LastPurchasePrice { get; set; }
    public string ImageName { get; set; }
    public bool IsUpdate { get; set; }

    public int ProductGroup3Id { get; set; }
    public ProductGroup2 productGroup3 { get; set; }

    public int ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; }

    public bool SendToServer { get; set; } = false;
    public decimal LastPurchasePriceNoCost { get; set; }
    public string Field4 { get; set; }
    public string Field5 { get; set; }
    public string Located { get; set; }
    public long GovermentTaxId { get; set; }
    public int SellerId { get; set; }
    public int TaxUnitId { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }
    public bool CheckList { get; set; } = false;
}

public enum ProductType
{
    Sales = 0,
    Materials = 1,
    Production = 2,
    Abandoned = 3,
    Services = 4
}