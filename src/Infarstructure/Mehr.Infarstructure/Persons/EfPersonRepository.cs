using Mehr.Domain.Contacts;
using Mehr.Domain.Entities.Costs;
using Mehr.Domain.Entities.Persons;
using Mehr.Domain.Persons;
using Mehr.Domain.Persons.Contracts;

namespace Mehr.Infarstructure.Persons;
public class EfPersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _context;

    public EfPersonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Person person, CancellationToken cancellationToken)
    {
        await _context.Persons.AddAsync(person);
    }

    public async Task<Person?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var person = _context.Persons
            .Where(x => x.Id == id)
            .Select(x => new
            {
                x.FirstGroupId,
                x.SecondGroupId,
                x.VisitorPercent,
                x.Comment,
                x.Introducer,
                x.Code,
                x.SalePriceId,
                x.ContactInfoId,
                x.VisitorCostId,
                x.VisitorBaseAmount,
                x.VisitorIncreaseAmount,
                x.VisitorIncresePercent,
                x.VisitorAutoDoc,
                x.VisitorGoodActiveStatus,
                x.VisitorPercentActiveStatus,
                x.VisitorProductGroupId,
                x.KindId,
                x.IsForeign,
                x.VisitorPercentChanging,

                x.ShopName,
                x.CardNumber,
                x.CardId1,
                x.CardId2,
                x.BirthdayDate,
                x.Password,
                x.Credit,

                x.PersonCustomerKindId,
                x.PersonCommercialId,
                x.Resume,
                x.ShippingComment,
                x.FirstVisitorId,
                x.SecondVisitorId,
                x.VisitorColor,

                x.IsDriver,
                x.IsEmployee,
                x.IsDistributor,
                x.IsUpdate,
                x.TaxKindId,
                x.CreateAt,
                x.UpdateAt,
                x.EshopId
            }
            ).FirstOrDefault();
        return await _context.Persons.FindAsync(id, cancellationToken);
    }
}
