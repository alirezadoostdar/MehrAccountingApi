using Mehr.Application.Docs.Contracts;
using Mehr.Domain.Entities.Docs.Dtos;
using Mehr.Domain.Interfaces.Docs;
using Mehr.SharedKernel;

namespace Mehr.Application.Docs;

public class DocService : IDocService
{
    private readonly IDocRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DocService(IDocRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetDocDto>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var doc =await _repository.GetByIdAsync(id, cancellationToken);

        return new GetDocDto
        {
            Id = doc.Id,
            Comment = doc.Comment,
            ShamsiDate = doc.ShamsiDate,
        };
    }
}
