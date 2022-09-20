using KodlamaioDevs.Application.Services.Repositories;

namespace KodlamaioDevs.Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologyBusinessRules
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologRepository;
        public ProgrammingTechnologyBusinessRules(IProgrammingTechnologyRepository programmingTechnologRepository)
        {
            _programmingTechnologRepository = programmingTechnologRepository;
        }

    }
}
