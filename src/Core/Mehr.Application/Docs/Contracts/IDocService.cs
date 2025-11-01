using Mehr.Domain.Entities.Docs.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.Docs.Contracts;
public interface IDocService
{
    Task<Result<GetDocDto>> GetByIdAsync(int id, CancellationToken cancellationToken );
}
