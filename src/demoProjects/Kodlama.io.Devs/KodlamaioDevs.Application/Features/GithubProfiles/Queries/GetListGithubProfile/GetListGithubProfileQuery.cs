using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.GithubProfiles.Models;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KodlamaioDevs.Application.Features.GithubProfiles.Queries.GetListGithubProfile
{
    public class GetListGithubProfileQuery : IRequest<GithubProfileListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListGithubProfileQueryHandler : IRequestHandler<GetListGithubProfileQuery, GithubProfileListModel>
        {
            private readonly IGithubProfileRepository _githubProfileRepository;
            private readonly IMapper _mapper;

            public GetListGithubProfileQueryHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper)
            {
                _githubProfileRepository = githubProfileRepository;
                _mapper = mapper;
            }

            public async Task<GithubProfileListModel> Handle(GetListGithubProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GithubProfile> githubProfiles = await _githubProfileRepository.GetListAsync(
                                                                                                      include: x => x.Include(x => x.User),
                                                                                                      index: request.PageRequest.Page,
                                                                                                      size: request.PageRequest.PageSize
                                                                                                      );
                GithubProfileListModel mappedGithubProfiles = _mapper.Map<GithubProfileListModel>(githubProfiles);
                return mappedGithubProfiles;
            }
        }
    }
}
