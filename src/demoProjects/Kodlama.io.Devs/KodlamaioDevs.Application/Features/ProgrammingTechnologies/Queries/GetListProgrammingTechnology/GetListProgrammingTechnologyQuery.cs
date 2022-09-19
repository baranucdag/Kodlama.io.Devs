using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.ProgrammingTechnologies.Modes;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KodlamaioDevs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnology
{
    public class GetListProgrammingTechnologyQuery : IRequest<ProgrammingTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingTechnologyQueryHandler : IRequestHandler<GetListProgrammingTechnologyQuery, ProgrammingTechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingTechnologRepository _programmingTechnologyRepository;

            public GetListProgrammingTechnologyQueryHandler(IMapper mapper, IProgrammingTechnologRepository programmingTechnologyRepository)
            {
                _mapper = mapper;
                _programmingTechnologyRepository = programmingTechnologyRepository;
            }

            public async Task<ProgrammingTechnologyListModel> Handle(GetListProgrammingTechnologyQuery request, CancellationToken cancellationToken)
            {

                IPaginate<ProgrammingTechnology> programmingTechnologies = await _programmingTechnologyRepository.GetListAsync(
                                                                            include: x => x.Include(x => x.ProgrammingLanguage),
                                                                            index: request.PageRequest.Page,
                                                                            size: request.PageRequest.PageSize);
                ProgrammingTechnologyListModel mappedProgrammingTechnologies = _mapper.Map<ProgrammingTechnologyListModel>(programmingTechnologies);
                return mappedProgrammingTechnologies;
            }
        }
    }
}
