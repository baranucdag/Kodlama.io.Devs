using AutoMapper;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Rules;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;

namespace KodlamaioDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
    {
        public string Name { get; set; }
        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
        {
            private readonly IPogrammingLanguageRepository _pogrammingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules programmingLanguageBusinessRules;
            public CreateProgrammingLanguageCommandHandler(IPogrammingLanguageRepository pogrammingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _pogrammingLanguageRepository = pogrammingLanguageRepository;
                _mapper = mapper;
                this.programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await programmingLanguageBusinessRules.ProgrammingLanguageCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createdProgrammingLanguage = await _pogrammingLanguageRepository.AddAsync(mappedProgrammingLanguage);
                CreatedProgrammingLanguageDto createdProgrammingLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdProgrammingLanguage);

                return createdProgrammingLanguageDto;

            }

        }
    }
}
