using Core.Persistence.Repositories;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Services.Repositories
{
    public interface IProgrammingTechnologyRepository : IAsyncRepository<ProgrammingTechnology>, IRepository<ProgrammingTechnology>
    {
    }
}
