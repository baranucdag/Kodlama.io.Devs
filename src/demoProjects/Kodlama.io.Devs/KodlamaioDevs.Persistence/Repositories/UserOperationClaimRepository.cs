using Core.Persistence.Repositories;
using Core.Security.Entities;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Persistence.Contexts;

namespace KodlamaioDevs.Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(BaseDbContext context) : base(context)
        {
        }

    }
}
