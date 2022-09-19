using KodlamaioDevs.Application.Services.Repositories;

namespace KodlamaioDevs.Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologyBusinessRules
    {
        private readonly IProgrammingTechnologRepository _programmingTechnologRepository;
        public ProgrammingTechnologyBusinessRules(IProgrammingTechnologRepository programmingTechnologRepository)
        {
            _programmingTechnologRepository = programmingTechnologRepository;
        }

    }
}
