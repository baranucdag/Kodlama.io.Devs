using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace KodlamaioDevs.Application.Services.Repositories
{
    public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
    {
    }
}
