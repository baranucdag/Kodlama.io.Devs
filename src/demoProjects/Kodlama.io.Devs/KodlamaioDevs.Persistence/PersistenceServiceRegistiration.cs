using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Persistence.Contexts;
using KodlamaioDevs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KodlamaioDevs.Persistence
{
    public static class PersistenceServiceRegistiration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("KodlamaioDevsConnectionString")));
            services.AddScoped<IPogrammingLanguageRepository, ProgrammingLanguageRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProgrammingTechnologyRepository, ProgrammingTechnologyRepository>();
            services.AddScoped<IGithubProfileRepository, GithubProfileRepository>();

            return services;
        }
    }
}
