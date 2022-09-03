using AutoMapper;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Rules;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;

namespace KodlamaioDevs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQuery : IRequest<ProgrammingLanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageGetByIdDto>
        {
            private readonly IPogrammingLanguageRepository _pogrammingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;
            public GetByIdProgrammingLanguageQueryHandler(IPogrammingLanguageRepository pogrammingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _mapper = mapper;
                _pogrammingLanguageRepository = pogrammingLanguageRepository;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }
            public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguage = await _pogrammingLanguageRepository.GetAsync(x => x.Id == request.Id);
                _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);
                ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto = _mapper.Map<ProgrammingLanguageGetByIdDto>(programmingLanguage);

                return programmingLanguageGetByIdDto;
            }
        }
    }
}
