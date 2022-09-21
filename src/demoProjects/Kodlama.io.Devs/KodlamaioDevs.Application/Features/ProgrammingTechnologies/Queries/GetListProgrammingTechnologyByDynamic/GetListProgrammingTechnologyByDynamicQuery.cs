using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Rules;
using KodlamaioDevs.Application.Features.ProgrammingTechnologies.Modes;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KodlamaioDevs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyByDynamic
{
    public class GetListProgrammingTechnologyByDynamicQuery : IRequest<ProgrammingTechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingTechnologiesByDynamicQueryHandler : IRequestHandler<GetListProgrammingTechnologyByDynamicQuery, ProgrammingTechnologyListModel>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules programmingLanguageBusinessRules;

            public GetListProgrammingTechnologiesByDynamicQueryHandler(
                IProgrammingTechnologyRepository programmingTechnologyRepository,
                IMapper mapper,
                ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                this.programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<ProgrammingTechnologyListModel> Handle(GetListProgrammingTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingTechnology> programmingTechnologies = await _programmingTechnologyRepository.GetListByDynamicAsync(
                    request.Dynamic, include: x => x.Include(x => x.ProgrammingLanguage),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                ProgrammingTechnologyListModel mappedProgrammingTechnologies = _mapper.Map<ProgrammingTechnologyListModel>(programmingTechnologies);
                return mappedProgrammingTechnologies;
            }
        }
    }
}
