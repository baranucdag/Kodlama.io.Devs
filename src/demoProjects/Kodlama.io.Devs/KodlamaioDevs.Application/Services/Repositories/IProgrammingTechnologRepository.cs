using Core.Persistence.Repositories;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Services.Repositories
{
    public interface IProgrammingTechnologRepository : IAsyncRepository<ProgrammingTechnology>, IRepository<ProgrammingTechnology>
    {
    }
}
