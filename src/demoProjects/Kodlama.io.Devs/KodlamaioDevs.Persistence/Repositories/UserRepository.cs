using Core.Persistence.Repositories;
using Core.Security.Entities;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Persistence.Contexts;

namespace KodlamaioDevs.Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }

    }
}
