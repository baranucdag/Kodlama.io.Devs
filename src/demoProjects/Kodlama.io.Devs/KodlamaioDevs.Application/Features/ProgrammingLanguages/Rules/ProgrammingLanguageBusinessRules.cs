using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IPogrammingLanguageRepository _pogrammingLanguageRepository;
        public ProgrammingLanguageBusinessRules(IPogrammingLanguageRepository pogrammingLanguageRepository)
        {
            _pogrammingLanguageRepository = pogrammingLanguageRepository;
        }

        public async Task ProgrammingLanguageCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _pogrammingLanguageRepository.GetListAsync(x => x.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programing language already exist");
        }

        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested programming language does not exist!");
        }
    }
}
