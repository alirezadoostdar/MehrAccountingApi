using Mehr.Domain.Persons;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Persons;

//public class PersonEntityMap : IEntityTypeConfiguration<Person>
//{
//    public void Configure(EntityTypeBuilder<Person> builder)
//    {
//        builder.ToTable("PersonTbl", tb =>
//        {
//            tb.Property(e => e.Id).HasColumnName("Fk_AccountSysCode");
//        });

//        builder.Property(x => x.FirstGroupId)
//           .HasColumnName("GroupId1");

//        builder.Property(x => x.SecondGroupId)
//            .HasColumnName("GroupId2");

//        builder.Property(x => x.VisitorPercent)
//            .HasColumnName("VisitorPer")
//            .IsRequired();

//        builder.Property(x => x.Comment)
//            .HasMaxLength(1000)
//            .IsRequired();

//        builder.Property(x => x.Introducer)
//            .IsRequired();

//        builder.Property(x => x.SalePriceId)
//            .HasColumnName("SalePriceNo")
//            .IsRequired();

//        builder.HasOne(x => x.SalePrice)
//            .WithMany()
//            .HasForeignKey(x => x.SalePriceId);

//        builder.Property(x => x.ContactInfoId)
//            .HasColumnName("ContactId");

//        builder.HasOne(x => x.ContactInfo)
//            .WithMany()
//            .HasForeignKey(x => x.ContactInfoId);

//        builder.Property(x => x.VisitorCostId)
//            .HasColumnName("VisitorCostAcc");

//        builder.Property(x => x.VisitorBaseAmount)
//            .HasColumnName("VisitorBaseAmmount");

//        builder.Property(x => x.VisitorIncreaseAmount)
//            .HasColumnName("VisitorIncreaseAmmount");

//        builder.Property(x => x.VisitorIncresePercent)
//            .HasColumnName("VisitorIncreasePer");

//        builder.Property(x => x.VisitorAutoDoc)
//            .IsRequired();

//        builder.Property(x => x.VisitorGoodStatus)
//            .HasColumnName("VisitorGoodActiveStat")
//            .IsRequired();

//        builder.Property(x => x.VisitorPercentActiveStatus)
//            .HasColumnName("VisitorPerActiveStat")
//            .IsRequired();

//        builder.Property(x => x.VisitorProductGroupId)
//            .HasColumnName("VisitorGoodGroupCode");

//        builder.Property(x => x.KindId)
//            .HasColumnName("FK_IDKind");

//        builder.HasOne(x => x.Kind)
//            .WithMany()
//            .HasForeignKey(x => x.KindId);

//        builder.Property(x => x.IsForeign)
//            .HasColumnName("OutSidePerson");

//        builder.Property(x => x.VisitorPercentChanging)
//            .HasColumnName("VisitorPerChanging");

//        builder.Property(x => x.CardNumber)
//            .HasColumnName("Cardno");

//        builder.Property(x => x.CardId1)
//            .HasColumnName("CardID1");

//        builder.Property(x => x.CardId2)
//            .HasColumnName("CardID2");

//        builder.Property(x => x.BirthdayDate)
//            .HasColumnName("birthDayDate")
//            .HasMaxLength(10);

//        builder.Property(x => x.Password)
//            .HasColumnName("Pass");

//        builder.Property(x => x.PersonCustomerKindId)
//            .HasColumnName("FK_PersonCutomerKind");

//        builder.Property(x => x.PersonCommercialId)
//            .HasColumnName("FK_PersonCommercial");

//        builder.Property(x => x.ShippingComment)
//            .HasColumnName("ShippComment");

//        builder.Property(x => x.FirstVisitorId)
//            .HasColumnName("Visitor1SysCode");

//        builder.Property(x => x.SecondVisitorId)
//            .HasColumnName("Visitor2SysCode");

//        builder.Property(x => x.TaxKindId)
//            .HasColumnName("Fk_TaxPersonKindId");

//        builder.Property(x => x.CreateAt)
//            .HasColumnName("CreateDateTime");

//        builder.Property(x => x.UpdateAt)
//            .HasColumnName("UpdateDateTime");

//        builder.Property(x => x.EshopId)
//            .HasColumnName("eShopId")
//            .HasMaxLength(200);

//    }
//}
